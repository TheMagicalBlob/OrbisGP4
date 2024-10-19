using System.IO;
using System.Xml;
#pragma warning disable CS1587

/////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\
///# Contents:                                  \\\
///--> Functions to Create Various .gp4 Elements \\\
/////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\

namespace libgp4 {
    public partial class GP4Creator {


        /////////////////////\\\\\\\\\\\\\\\\\\\
        ///--     GP4 ELEMENT CREATION     --\\\
        /////////////////////\\\\\\\\\\\\\\\\\\\
        #region GP4 ELEMENT CREATION

        /// <summary>
        ///  Create Base .gp4 Elements (Up To The Start Of The chunk_info Node).
        ///   <br/><br/>
        /// - psproject <br/>
        /// - volume <br/>
        /// - volume_type <br/>
        /// - volume_id <br/>
        /// - volume_ts <br/>
        /// - package <br/>
        /// - chunk_info <br/>
        /// </summary>
        private XmlNode[] CreateBaseElements(SfoParser sfo_data, PlaygoParameters playgo_data, XmlDocument gp4, string passcode, string base_package, string gp4_timestamp) {

            var psproject = gp4.CreateElement("psproject");
            psproject.SetAttribute("fmt", "gp4");
            psproject.SetAttribute("version", "1000");


            var volume = gp4.CreateElement("volume");

            var volume_type = gp4.CreateElement("volume_type");
            volume_type.InnerText = $"pkg_{((sfo_data.category == "gd") ? "ps4_app" : "ps4_patch")}";

            var volume_id = gp4.CreateElement("volume_id");
            volume_id.InnerText = "PS4VOLUME";

            var volume_ts = gp4.CreateElement("volume_ts");
            volume_ts.InnerText = gp4_timestamp;


            var package = gp4.CreateElement("package");
            package.SetAttribute("content_id", sfo_data.content_id);
            package.SetAttribute("passcode", passcode);
            package.SetAttribute("storage_type", ((sfo_data.category == "gp") ? "digital25" : "digital50"));
            package.SetAttribute("app_type", "full");


            if(sfo_data.category == "gp")
                package.SetAttribute("app_path", base_package ?? $"{sfo_data.content_id}-A{sfo_data.app_ver.Replace(".", "")}-V{sfo_data.version.Replace(".", "")}.pkg");
#if Log
            else if(sfo_data.category == "gd" && base_package != null) {
                var str = $"WARNING: A Base Game Package Path Was Given, But The Package Category Was Set To Full Game.\n(Base Package: {base_package})";
                DLog(str);
                WLog(str, true);
            }
#endif

            var chunk_info = gp4.CreateElement("chunk_info");
            chunk_info.SetAttribute("chunk_count", $"{playgo_data.chunk_count}");
            chunk_info.SetAttribute("scenario_count", $"{playgo_data.scenario_count}");

            return new XmlNode[] { psproject, volume, volume_type, volume_id, volume_ts, package, chunk_info };
        }


        /// <summary>
        /// Create "files" Element Containing File Destination And Source Paths, Along With Whether To Enable PFS Compression.
        /// </summary>
        private XmlNode CreateFilesElement(int chunk_count, string[][] extra_files, string[] file_paths, string gamedata_folder, XmlDocument gp4) {
            var files = gp4.CreateElement("files");

            for(var index = 0; index < file_paths.Length; index++) {
                if(FileShouldBeExcluded(file_paths[index]))
                    continue;

                var file = gp4.CreateElement("file");
                file.SetAttribute("targ_path", file_paths[index].Remove(0, gamedata_folder.Length + 1).Replace('\\', '/'));
                file.SetAttribute(
                    "orig_path",
                    _AbsoluteFilePaths ?
                    file_paths[index] :
                    file_paths[index].Remove(0, gamedata_folder.Length + 1) // Strip
                );

                if(!SkipPfsCompressionForFile(file_paths[index]))
                    file.SetAttribute("pfs_compression", "enable");

                if(!SkipChunkAttributeForFile(file_paths[index]) && chunk_count - 1 != 0)
                    file.SetAttribute("chunks", $"0-{chunk_count - 1}");

                files.AppendChild(file);
            }


            // Add Any Extra Files From The User (Test This)
            if(extra_files != null)
                for(var index = 0; index < extra_files.Length; index++) {
                    if(FileShouldBeExcluded(extra_files[index][1]))
                        continue;

                    var file = gp4.CreateElement("file");
                    file.SetAttribute("targ_path", (extra_files[index][0].Remove(0, gamedata_folder.Length + 1)).Replace('\\', '/'));
                    file.SetAttribute("orig_path", extra_files[index][1]);

                    if(!SkipPfsCompressionForFile(extra_files[index][1]))
                        file.SetAttribute("pfs_compression", "enable");

                    if(!SkipChunkAttributeForFile(extra_files[index][1]) && chunk_count - 1 != 0)
                        file.SetAttribute("chunks", $"0-{chunk_count - 1}");

                    files.AppendChild(file);
                }

            return files;
        }

        /// <summary> Create "rootdir" Element Containing The Game's File Structure through A Listing Of Each Directory And Subdirectory
        /// </summary>
        private XmlNode CreateRootDirectoryElement(string gamedata_folder, XmlDocument gp4) {
            var rootdir = gp4.CreateElement("rootdir");

            void AppendSubfolder(string dir, XmlElement node) {
                foreach(string folder in Directory.GetDirectories(dir)) {
                    var subdir = gp4.CreateElement("dir");
                    subdir.SetAttribute("targ_name", folder.Substring(folder.LastIndexOf('\\') + 1));

                    if(folder.Substring(folder.LastIndexOf('\\') + 1) != "about")
                        node.AppendChild(subdir);

                    if(Directory.GetDirectories(folder).Length > 0) AppendSubfolder(folder, subdir);
                }
            }

            foreach(string folder in Directory.GetDirectories(gamedata_folder)) {
                var dir = gp4.CreateElement("dir");
                dir.SetAttribute("targ_name", folder.Substring(folder.LastIndexOf('\\') + 1));

                rootdir.AppendChild(dir);
                if(Directory.GetDirectories(folder).Length > 0) AppendSubfolder(folder, dir);
            }

            return rootdir;
        }

        /// <summary> Create "chunks" Element
        /// </summary>
        private XmlNode CreateChunksElement(PlaygoParameters data, XmlDocument gp4) {
            var chunks = gp4.CreateElement("chunks");

            for(int chunk_id = 0; chunk_id < data.chunk_count; chunk_id++) {
                var chunk = gp4.CreateElement("chunk");
                chunk.SetAttribute("id", $"{chunk_id}");

                if(data.chunk_labels[chunk_id] == "") //  I Hope This Fix Works For Every Game...
                    chunk.SetAttribute("label", $"Chunk #{chunk_id}");
                else
                    chunk.SetAttribute("label", $"{data.chunk_labels[chunk_id]}");
                chunks.AppendChild(chunk);
            }
            return chunks;
        }

        /// <summary> Create "scenarios" Element
        /// </summary>
        private XmlNode CreateScenariosElement(PlaygoParameters data, XmlDocument gp4) {
            var scenarios = gp4.CreateElement("scenarios");
            scenarios.SetAttribute("default_id", $"{data.default_scenario_id}");

            for(var index = 0; index < data.scenario_count; index++) {
                var scenario = gp4.CreateElement("scenario");

                scenario.SetAttribute("id", $"{index}");
                scenario.SetAttribute("type", $"{(data.scenario_types[index] == 1 ? "sp" : "mp")}");
                scenario.SetAttribute("initial_chunk_count", $"{data.initial_chunk_count[index]}");
                scenario.SetAttribute("label", $"{data.scenario_labels[index]}");

                if(data.scenario_chunk_range[index] - 1 != 0)
                    scenario.InnerText = $"0-{data.scenario_chunk_range[index] - 1}";

                else scenario.InnerText = "0";

                scenarios.AppendChild(scenario);
            }

            return scenarios;
        }

        /// <summary> Build .gp4 Structure And Save To File
        ///</summary>
        /// <returns> Time Taken For Build Process </returns>
        private void BuildGp4Elements(XmlDocument gp4_project, XmlNode[] base_elements, XmlNode chunks, XmlNode scenarios, XmlNode files, XmlNode rootdir) {

            gp4_project.AppendChild(gp4_project.CreateXmlDeclaration("1.1", "utf-8", "yes"));
            gp4_project.AppendChild(base_elements[0]);      // psproject

            base_elements[0].AppendChild(base_elements[1]); // volume
            base_elements[1].AppendChild(base_elements[2]); // volume_type
            base_elements[1].AppendChild(base_elements[3]); // volume_id
            base_elements[1].AppendChild(base_elements[4]); // volume_ts
            base_elements[1].AppendChild(base_elements[5]); // package
            base_elements[1].AppendChild(base_elements[6]); // chunk_info

            base_elements[6].AppendChild(chunks);
            base_elements[6].AppendChild(scenarios);
            base_elements[0].AppendChild(files);
            base_elements[0].AppendChild(rootdir);

            gp4_project.AppendChild(gp4_project.CreateComment("gengp4.exe Alternative. {//! add a link to the library repository once you change it to public!!!}")); //!
        }


        /// <summary>
        /// Check Whether The filepath Containts A Blacklisted String.<br/>
        /// Checks Both A Default String[] Of Blacklisted Files, As Well As Any User Blacklisted Files/Folders.
        /// </summary>
        /// <returns> True If The File in filepath Shouldn't Be Included In The .gp4 </returns>
        private bool FileShouldBeExcluded(string filepath) {
            if(filepath.Contains("sce_sys") && filepath.Contains(".dds")) {
                WLog("Ignoring .dds In System Folder.", true);
                return true;
            }

            foreach(var blacklisted_file_or_folder in DefaultBlacklist)
                if(filepath.Contains(blacklisted_file_or_folder)) {
#if Log
                    WLog($"Ignoring: {filepath}", true);
#endif
                    return true;
                }

            if(_BlacklistedFilesOrFolders != null)
                foreach(var blacklisted_file_or_folder in _BlacklistedFilesOrFolders) {
                    if(filepath.Contains(blacklisted_file_or_folder)) {
#if Log
                        WLog($"User Ignoring: {filepath}", true);
#endif
                        return true;
                    }
                }
            return false;
        }


        /// <summary>
        /// Check Whether Or Not The File At filepath Should Have Pfs Compression Enabled.<br/>
        /// This Is Almost Certainly Incomplete. Need More Brain Juice.
        /// </summary>
        /// <returns> True If Pfs Compression Should Be Enabled. </returns>
        private bool SkipPfsCompressionForFile(string filepath) {
            // TOTO: Figure Out How To Dynamically
            foreach(var file in new string[] {
                "sce_sys",
                "sce_module",
                ".elf",
                ".bin",
                ".prx",
                ".dll"
            })
            if(filepath.Contains(file))
                return true;

            return false;
        }


        /// <summary>
        /// Check Whether Or Not The File At filepath Should Have The "chunks" Attribute.<br/>
        /// [This Is Almost Certainly Incomplete. Need More Brain Juice.]
        /// </summary>
        /// <returns> True If The Chunk Attribute Should Be Skipped. </returns>
        private bool SkipChunkAttributeForFile(string filepath) {
            foreach(var filter in new string[] {
                "keystone",
                "sce_sys",
                "sce_module",
                ".bin"
            })
            if(filepath.Contains(filter))
                return true;

            return false;
        }
        #endregion
    }
}
