System.UnauthorizedAccessException was unhandled
  HResult=-2147024891
  Message=???????? ? ??????? ?? ???? "C:\Windows.old\WINDOWS\Temp".
  Source=mscorlib
  StackTrace:
       ? System.IO.__Error.WinIOError(Int32 errorCode, String maybeFullPath)
       ? System.IO.FileSystemEnumerableIterator`1.CommonInit()
       ? System.IO.FileSystemEnumerableIterator`1..ctor(String path, String originalUserPath, String searchPattern, SearchOption searchOption, SearchResultHandler`1 resultHandler, Boolean checkHost)
       ? System.IO.DirectoryInfo.InternalGetDirectories(String searchPattern, SearchOption searchOption)
       ? System.IO.DirectoryInfo.GetDirectories()
       ? GY76KGW2LP1G4.Program.Look(String path) ? c:\users\goya76king\documents\visual studio 2015\Projects\GY76KGW2LG4\GY76KGW2LP1G4\Program.cs:?????? 19
       ? GY76KGW2LP1G4.Program.Main(String[] args) ? c:\users\goya76king\documents\visual studio 2015\Projects\GY76KGW2LG4\GY76KGW2LP1G4\Program.cs:?????? 42
       ? System.AppDomain._nExecuteAssembly(RuntimeAssembly assembly, String[] args)
       ? System.AppDomain.ExecuteAssembly(String assemblyFile, Evidence assemblySecurity, String[] args)
       ? Microsoft.VisualStudio.HostingProcess.HostProc.RunUsersAssembly()
       ? System.Threading.ThreadHelper.ThreadStart_Context(Object state)
       ? System.Threading.ExecutionContext.RunInternal(ExecutionContext executionContext, ContextCallback callback, Object state, Boolean preserveSyncCtx)
       ? System.Threading.ExecutionContext.Run(ExecutionContext executionContext, ContextCallback callback, Object state, Boolean preserveSyncCtx)
       ? System.Threading.ExecutionContext.Run(ExecutionContext executionContext, ContextCallback callback, Object state)
       ? System.Threading.ThreadHelper.ThreadStart()
  InnerException: 
