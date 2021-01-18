using System.IO;

// https://stackoverflow.com/a/452945/148962

namespace Cyotek.DownDetector.Client
{
  internal static class StreamUtil
  {
    #region Public Methods

    public static void ReadExactly(Stream input, byte[] buffer, int bytesToRead)
    {
      int index = 0;
      while (index < bytesToRead)
      {
        int read = input.Read(buffer, index, bytesToRead - index);
        if (read == 0)
        {
          throw new EndOfStreamException
              (string.Format("End of stream reached with {0} byte{1} left to read.",
                             bytesToRead - index,
                             bytesToRead - index == 1 ? "s" : ""));
        }
        index += read;
      }
    }

    #endregion Public Methods
  }
}