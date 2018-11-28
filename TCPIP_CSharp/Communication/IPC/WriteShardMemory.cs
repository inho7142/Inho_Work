using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using GloryCimProtocol;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO.MemoryMappedFiles;
using System.Data;
using System.IO;
using System.IO.Compression;

namespace Communication.IPC
{
    public class WriteShardMemory
    {
        #region Constructor, destructor
        public WriteShardMemory()
        {

        }

        ~ WriteShardMemory()
        {

        }
        #endregion

        //public void MMFWriteStart(string serviceName)
        //{
        //    // Mapping된 file 가져오기
        //    MemoryMappedFile mapFile = MemoryMappedFile.OpenExisting(serviceName, MemoryMappedFileRights.ReadWrite);
        //    MemoryMappedViewAccessor accessor = mapFile.CreateViewAccessor();
        //    // 공유 Memory에 쓰기
        //    byte[] Buffer = ASCIIEncoding.ASCII.GetBytes("심S님"+ "\0");
        //    accessor.WriteArray(0, Buffer, 0, Buffer.Length);
        //    accessor.Dispose();
        //    mapFile.Dispose();
        //}

        ////--------------------------------------------------------------------------------
        //public Byte[] ReadMMFAllBytes(string fileName)
        //{
        //    using (var mmf = MemoryMappedFile.OpenExisting(fileName))
        //    {
        //        using (var stream = mmf.CreateViewStream())
        //        {
        //            using (BinaryReader binReader = new BinaryReader(stream))
        //            {
        //                return binReader.ReadBytes((int)stream.Length);
        //            }
        //        }
        //    }
        //}

        //public object ByteArrayToObject(byte[] buffer)
        //{
        //    BinaryFormatter binaryFormatter = new BinaryFormatter(); // Create new BinaryFormatter
        //    MemoryStream memoryStream = new MemoryStream(buffer);    // Convert buffer to memorystream
        //    return binaryFormatter.Deserialize(memoryStream);        // Deserialize stream to an object
        //}

        //public DataSet ReadFromMemoryMaptt(string fileName)
        //{
        //    byte[] nbytes = null;

        //    using (var mmf = MemoryMappedFile.OpenExisting(fileName))
        //    {
               
        //        using (var stream = mmf.CreateViewStream())
        //        {
        //            using (BinaryReader binReader = new BinaryReader(stream))
        //            {
        //                nbytes = binReader.ReadBytes((int)stream.Length);
        //            }

        //            using (System.IO.MemoryMappedFiles.MemoryMappedViewAccessor accessor = mmf.CreateViewAccessor())
        //            {
        //                accessor.ReadArray(0, nbytes, 0, nbytes.Length);
        //            }
        //        }
        //    }
        //    return DecompressData(nbytes);
        //}

          
        ////--------------------------------------------------------------------------------

        //static byte[] ReadMemoryMappedFile(string fileName)
        //{
        //    long length = new FileInfo(fileName).Length;
        //    using (var stream = File.Open(fileName, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite))
        //    {
        //        using (var mmf = MemoryMappedFile.CreateFromFile(stream, null, length, MemoryMappedFileAccess.Read, null, HandleInheritability.Inheritable, false))
        //        {
        //            using (var viewStream = mmf.CreateViewStream(0, length, MemoryMappedFileAccess.Read))
        //            {
        //                using (BinaryReader binReader = new BinaryReader(viewStream))
        //                {
        //                    var result = binReader.ReadBytes((int)length);
        //                    return result;
        //                }
        //            }
        //        }
        //    }
        //}

        //private static void WriteData(string fileName, byte[] data)
        //{
        //    using (var stream = File.Open(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
        //    {
        //        using (var mmf = MemoryMappedFile.CreateFromFile(stream, null, data.Length, MemoryMappedFileAccess.ReadWrite, null, HandleInheritability.Inheritable, true))
        //        {
        //            using (var view = mmf.CreateViewAccessor())
        //            {
        //                view.WriteArray(0, data, 0, data.Length);
        //            }
        //        }

        //        stream.SetLength(data.Length);  // Make sure the file is the correct length, in case the data got smaller.
        //    }
        //}

        ////--------------------------------------------------------------------------------
        
        //public void WriteToMemoryMap(DataSet ds, string key, string fileName)
        //{
        //    var bytes = CompressData(ds);
        //    using (System.IO.MemoryMappedFiles.MemoryMappedFile objMf = System.IO.MemoryMappedFiles.MemoryMappedFile.CreateFromFile(fileName, System.IO.FileMode.OpenOrCreate, key, bytes.Length))
        //    {
        //        using (System.IO.MemoryMappedFiles.MemoryMappedViewAccessor accessor = objMf.CreateViewAccessor())
        //        {
        //            accessor.WriteArray(0, bytes, 0, bytes.Length);
        //        }
        //    }
        //}
        //public DataSet ReadFromMemoryMap(string fileName)
        //{
        //    var fi = new FileInfo(fileName);
        //    var length = (int)fi.Length;
        //    var newBytes = new byte[length];
        //    using (System.IO.MemoryMappedFiles.MemoryMappedFile objMf = System.IO.MemoryMappedFiles.MemoryMappedFile.CreateFromFile(fileName, FileMode.Open))
        //    {
        //        using (System.IO.MemoryMappedFiles.MemoryMappedViewAccessor accessor = objMf.CreateViewAccessor())
        //        {
        //            accessor.ReadArray(0, newBytes, 0, length);
        //        }
        //    }
        //    return DecompressData(newBytes);
        //}
        //public byte[] CompressData(DataSet ds)
        //{
        //    try
        //    {
        //        byte[] data = null;
        //        var memStream = new MemoryStream();
        //        var zipStream = new GZipStream(memStream, CompressionMode.Compress);
        //        ds.WriteXml(zipStream, XmlWriteMode.WriteSchema);
        //        zipStream.Close();
        //        data = memStream.ToArray();
        //        memStream.Close();
        //        return data;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
        //public DataSet DecompressData(byte[] data)
        //{
        //    try
        //    {
        //        var memStream = new MemoryStream(data);
        //        var unzipStream = new GZipStream(memStream, CompressionMode.Decompress);
        //        var objDataSet = new DataSet();
        //        objDataSet.ReadXml(unzipStream, XmlReadMode.ReadSchema);
        //        unzipStream.Close();
        //        memStream.Close();
        //        return objDataSet;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

    }
}



