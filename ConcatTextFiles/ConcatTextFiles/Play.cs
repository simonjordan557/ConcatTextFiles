using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConcatTextFiles
{
    class Play
    {
        List<string> toWrite = new List<string>();
        string writePath;

        public void Go(string path)
        {
            try
            {
                writePath = path + @"\results.txt";
                string[] directoryList = Directory.GetDirectories(path);



                Console.WriteLine($"Number of directories: {directoryList.Length}.");

                if (directoryList.Length == 0)
                {
                    ExtractTxtFileContentsFromDirectory(path);
                }

                else
                {
                    foreach (var directory in directoryList)
                    {
                        ExtractTxtFileContentsFromDirectory(directory);
                    }
                }

                if (File.Exists(writePath))
                {
                    File.Delete(writePath);
                }

                foreach (var line in toWrite)
                {

                    Console.WriteLine(line);

                    

                    using (StreamWriter sw = new StreamWriter(writePath, true))
                    {
                        sw.WriteLine(line);
                    }
                }

                using (StreamWriter sw = new StreamWriter(writePath, true))
                {
                    sw.WriteLine($"\n\n**** FILE COMPLETE. THANKS FOR CONCATENATING! ****");
                }




            }

            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine($"PROGRAM FAILED! INVALID PATH.\n\n" + e.Message);
                Console.WriteLine("\nEnter a valid path: ");
                path = Console.ReadLine();
                Go(path);
            }

            
        }

        private void ExtractTxtFileContentsFromDirectory(string path)
        {
            string[] fileList = Directory.GetFiles(path, "*.txt");

            foreach (var file in fileList)
            {
                if (file == writePath)
                {
                    continue;
                }

                toWrite.Add($"\n\n{file}\n");
                using (StreamReader sr = new StreamReader(file))
                {
                    while (!sr.EndOfStream)
                    {
                        toWrite.Add(sr.ReadLine());
                    }

                    toWrite.Add("\n\n");
                }


            }
        }
        


    }
}
