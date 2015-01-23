using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace NSCC.Web.Awards.Managers
{
    public class FilenameHelper
    {
        public string GetFilename(string path, string desiredFilename)
        {
            string fileName = Path.GetFileNameWithoutExtension(desiredFilename);
            string ext = Path.GetExtension(desiredFilename);

            string[] matchingFiles = Directory.GetFiles(path, fileName + "*" + ext, SearchOption.AllDirectories);
            if (matchingFiles.Length > 0)
            {
                List<int> fileCount = new List<int>();

                foreach (string t in matchingFiles)
                {
                    string oneFile = Path.GetFileName(t);
                    int versionStartPos = oneFile.IndexOf("(", StringComparison.Ordinal);
                    if (versionStartPos != -1)
                    {
                        // At least one extra copy of file exists
                        int versionEndPos = oneFile.IndexOf(")", StringComparison.Ordinal);
                        if (versionEndPos != -1)
                        {
                            int numLength = versionEndPos - versionStartPos;
                            string verNum = oneFile.Substring(versionStartPos + 1, numLength - 1);

                            fileCount.Add(Int32.Parse(verNum));
                        }
                    }
                    else
                    {
                        // Initial file version
                        fileCount.Add(0);
                    }
                }

                int maxNumber = fileCount.Max() + 1;

                return fileName + " (" + maxNumber + ")" + ext;
            }

            return desiredFilename;
        }
    }
}