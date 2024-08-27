using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs; //using CommonOpenFileDialog

namespace uhf.kFunc
{
  internal static class Dir
  {
    /* 경로의 폴더가 존재하는지 */
    public static bool DirExist(string path)
    {
      DirectoryInfo dir = new DirectoryInfo(path);
      if (!dir.Exists) return false;
      return true;
    }

    /* 경로의 폴더 만들기 */
    public static void DirMake(string path)
    {
      DirectoryInfo dir = new DirectoryInfo(path);
      if (dir.Exists) return;
      dir.Create();
    }

    /* 경로의 파일이 존재하는지 */
    public static bool FileExist(string path)
    {
      FileInfo file = new FileInfo(path);
      if (!file.Exists) return false;
      return true;
    }

    /* 경로의 파일이 이미 열려 있는지 */
    public static bool IsFileOpen(string path)
    {
      FileInfo file = new FileInfo(path);
      FileStream stream = null;

      try
      {
        stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
      }
      catch (IOException)
      {
        //the file is unavailable because it is:
        //still being written to
        //or being processed by another thread
        //or does not exist (has already been processed)
        return true;
      }
      finally
      {
        if (stream != null)
          stream.Close();
      }
      return false;
    }

    /* 경로의 파일 만들기 */
    public static void FileMake(string path)
    {
      string dir = Path.GetDirectoryName(path);
      DirMake(dir);
      FileInfo file = new FileInfo(path);
      FileStream fs = file.Create();
      fs.Close();

    }

    /* 파일 이름 변경 */
    public static void RenameFile(string oldFile, string newFile)
    {
      File.Move(oldFile, newFile);
    }

    /* 파일 실행 경로 얻기 : 루트 디렉토리 ex) d:\\@project\\@dev\\a\\debug\\ */
    public static string GetRootDir()
    {
      string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
      return System.IO.Path.GetDirectoryName(path) + "\\";
    }

    /* 파일 전체 경로에서 디렉토리 얻기 ex) d:\\ */
    public static string GetDir(string path)
    {
			string str = NormalizePath(path);
      return Path.GetDirectoryName(str);
    }

    /* 파일 전체 경로에서 파일 이름 얻기 ex) a.jpg */
    public static string GetFileName(string path)
    {
      return Path.GetFileName(path);
    }

    /* 파일 전체 경로에서 파일 이름 얻기 - 확장자 빼고 ex) a */
    public static string GetFileNameWithoutExt(string path)
    {
      return Path.GetFileNameWithoutExtension(path);
    }

    /* 파일 확장자 얻기 ex) .jpg */
    public static string GetFileExt(string path)
    {
      return Path.GetExtension(path);
    }
   
    /* 파일 확장자 얻기 - 점 제거 ex) jpg */
    public static string GetFileExtWithoutDot(string path)
    {
      string str = Path.GetExtension(path);
      str = str.Trim('.');
      return str;
    }

    /* 파일 경로 얻기 - 확장자 제거 후 ex) d:\\a */
    public static string GetFilePathWithoutExt(string path)
    {
      string s = NormalizePath(path);
      return s.Remove(s.LastIndexOf('.'));
    }

    /* 파일 경로 일반화 ex) d:\\a.jpg */
    public static string NormalizePath(string path)
    {
      return Path.GetFullPath(new Uri(path).LocalPath)
                 .TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
                 //.ToUpperInvariant();
    }

    /* 파일 경로 일반화 - 대문자로 변경 ex) D:\\A.JPG */
    public static string NormalizePathUpper(string path)
    {
      return Path.GetFullPath(new Uri(path).LocalPath)
                 .TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
                 .ToUpperInvariant();
    }

    /* 현재 날짜 시간 얻기 */
    public static string GetCurrentDateTime()
    {
      DateTime dateTime = DateTime.Now;

      return string.Format("{0:yyMMdd_HHmmss}", dateTime);
    }

    /* 파일 다이얼로그를 오픈하여 파일 선택하여 그 파일 경로를 얻기 */
    public static bool OpenFile(string initDir, string ext, out string filePath)
    {
      filePath = "";
      using (OpenFileDialog openFileDialog = new OpenFileDialog())
      {
        openFileDialog.InitialDirectory = initDir;
        openFileDialog.Filter = ext + " files (*." + ext + ")|*." + ext + "|All files (*.*)|*.*";
        openFileDialog.FilterIndex = 2;
        openFileDialog.RestoreDirectory = true;

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
          //Get the path of specified file
          filePath = openFileDialog.FileName;

#if false
          //Read the contents of the file into a stream
          var fileStream = openFileDialog.OpenFile();

          using (StreamReader reader = new StreamReader(fileStream))
          {
            fileContent = reader.ReadToEnd();
          }
#endif
          return true;
        }
      }

      return false;
    }

    /* 파일 다이얼로그를 오픈하여 폴더를 선택하여 그 폴더 경로를 얻기 */
    public static bool OpenDir(out string dirPath)
    {
      dirPath = "";
      CommonOpenFileDialog dialog = new CommonOpenFileDialog();
      dialog.IsFolderPicker = true; //폴더 선택

      if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
      {
        dirPath = dialog.FileName;
        return true;
      }

      return false;
    }

    /* 디렉토리 리스트 얻기 */
    public static bool GetDirList(string path, out string[] p)
    {
      p = null;

      DirectoryInfo dir = new DirectoryInfo(path);

      DirectoryInfo[] list = dir.GetDirectories();

      if (list.Length < 1) return false;

      p = new string[list.Length];

      for(int i = 0; i < list.Length; i++)
      {
        p[i] = list[i].Name;
      }

      return true;
    }

    /* 디렉토리 전체 삭제 */
    public static void DeleteDirAll(string path)
    {
      DirectoryInfo dir = new DirectoryInfo(path);
      dir.Delete(true);
      System.GC.Collect();
      System.GC.WaitForPendingFinalizers();
    }

    /* 디렉토리 안에 파일이 없으면 삭제 */
    public static void DeleteDir(string path)
    {
      DirectoryInfo dir = new DirectoryInfo(path);
      dir.Delete();
      System.GC.Collect();
      System.GC.WaitForPendingFinalizers();
    }

    /* 디렉토리 카피 */
    public static void CopyDirectroy(string sourceDirName, string destDirName, bool copySubDirs)
    {
      // Get the subdirectories for the specified directory.
      DirectoryInfo dir = new DirectoryInfo(sourceDirName);

      if (!dir.Exists)
      {
        throw new DirectoryNotFoundException(
            "Source directory does not exist or could not be found: "
            + sourceDirName);
      }

      DirectoryInfo[] dirs = dir.GetDirectories();

      // If the destination directory doesn't exist, create it.       
      Directory.CreateDirectory(destDirName);

      // Get the files in the directory and copy them to the new location.
      FileInfo[] files = dir.GetFiles();
      foreach (FileInfo file in files)
      {
        string tempPath = Path.Combine(destDirName, file.Name);
        file.CopyTo(tempPath, false);
      }

      // If copying subdirectories, copy them and their contents to new location.
      if (copySubDirs)
      {
        foreach (DirectoryInfo subdir in dirs)
        {
          string tempPath = Path.Combine(destDirName, subdir.Name);
          CopyDirectroy(subdir.FullName, tempPath, copySubDirs);
        }
      }
    }
  }
}
