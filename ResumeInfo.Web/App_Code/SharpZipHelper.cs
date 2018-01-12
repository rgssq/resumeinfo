using System;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.GZip;

public static class SharpZipHelper
{
    public static void ZipFile(string sfile, string dfile)
    {
        try
        {
            FileStream fs = File.OpenRead(sfile);
            ZipFile(fs, dfile);
        }
        catch (Exception)
        {
            throw;
        }
    }
    public static void ZipFile(Stream sm, string dfile)
    {
        try
        {
            GZipOutputStream s = new GZipOutputStream(File.Create(dfile));
            byte[] writeData = new byte[sm.Length];
            sm.Read(writeData, 0, (int)sm.Length);
            s.Write(writeData, 0, writeData.Length);
            s.Close();
            sm.Close();
        }
        catch (Exception)
        {
            throw;
        }
    }
    public static void UnzipFile(string sfile, string dfile)
    {
        try
        {
            GZipInputStream s = new GZipInputStream(File.OpenRead(sfile));
            FileStream fs = File.Create(dfile);
            int size = 2048;
            byte[] writeData = new byte[2048];
            while (true)
            {
                size = s.Read(writeData, 0, size);
                if (size > 0)
                {
                    fs.Write(writeData, 0, size);
                }
                else
                {
                    break;
                }
            }
            s.Close();
            fs.Close();
        }
        catch (Exception)
        {
            throw;
        }
    }
    public static MemoryStream UnzipFileToStream(string sfile)
    {
        try
        {
            GZipInputStream s = new GZipInputStream(File.OpenRead(sfile));
            MemoryStream sm = new MemoryStream();
            int size = 2048;
            byte[] writeData = new byte[2048];
            while (true)
            {
                size = s.Read(writeData, 0, size);
                if (size > 0)
                {
                    sm.Write(writeData, 0, size);
                }
                else
                {
                    break;
                }
            }
            s.Close();
            return sm;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public static void ZipDirectory(string dir, string file)
    {
        try
        {
            FastZip fz = new FastZip();
            fz.CreateEmptyDirectories = true;
            fz.CreateZip(file, dir, true, "");
            fz = null;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public static bool UnzipFiles(string file, string dir)
    {
        try
        {
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            ZipInputStream s = new ZipInputStream(File.OpenRead(file));
            ZipEntry theEntry;
            while ((theEntry = s.GetNextEntry()) != null)
            {
                string directoryName = Path.GetDirectoryName(theEntry.Name);
                string fileName = Path.GetFileName(theEntry.Name);
                if (directoryName != String.Empty) Directory.CreateDirectory(dir + directoryName);
                if (fileName != String.Empty)
                {
                    FileStream streamWriter = File.Create(Path.Combine(dir, theEntry.Name));
                    int size = 2048;
                    byte[] data = new byte[2048];
                    while (true)
                    {
                        size = s.Read(data, 0, data.Length);
                        if (size > 0)
                        {
                            streamWriter.Write(data, 0, size);
                        }
                        else
                        {
                            break;
                        }
                    }
                    streamWriter.Close();
                }
            }
            s.Close();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
}