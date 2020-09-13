using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class LogHandler : ILogHandler
{
    public void LogFormat(LogType logType, UnityEngine.Object context, string format, params object[] args)
    {
        Debug.unityLogger.logHandler.LogFormat(logType, context, format, args);
    }

    public void LogException(Exception exception, UnityEngine.Object context)
    {
        Debug.unityLogger.LogException(exception, context);
    }
}

public class MyGameClass : MonoBehaviour
{
    private static string tag = "BlobbyVolley";
    private Logger myLogger;

    void Start()
    {
        myLogger = new Logger(new LogHandler());

        myLogger.Log(tag, "BlobbyVolley Start.");
    }
}