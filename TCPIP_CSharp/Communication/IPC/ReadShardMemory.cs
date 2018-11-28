using System;
using System.Text;
using System.IO.MemoryMappedFiles;
using System.IO;
using System.Threading;

namespace Communication.IPC
{
    public class ReadShardMemory
    {
        #region Constructor, destructor
        public ReadShardMemory()
        {

        }

        ~ ReadShardMemory()
        {

        }
        #endregion
        public void Create(string serviceName)
        {
            using (MemoryMappedFile mmf = MemoryMappedFile.CreateNew("testmap", 10000))
            {
                bool mutexCreated;
                Mutex mutex = new Mutex(true, "testmapmutex", out mutexCreated);
                using (MemoryMappedViewStream stream = mmf.CreateViewStream())
                {
                    BinaryWriter writer = new BinaryWriter(stream);
                    writer.Write(1);
                }
                mutex.ReleaseMutex();

                Console.WriteLine("Start Process B and press ENTER to continue.");
                Console.ReadLine();

                Console.WriteLine("Start Process C and press ENTER to continue.");
                Console.ReadLine();

                mutex.WaitOne();
                using (MemoryMappedViewStream stream = mmf.CreateViewStream())
                {
                    BinaryReader reader = new BinaryReader(stream);
                    Console.WriteLine("Process A says: {0}", reader.ReadBoolean());
                    Console.WriteLine("Process B says: {0}", reader.ReadBoolean());
                    Console.WriteLine("Process C says: {0}", reader.ReadBoolean());
                }
                mutex.ReleaseMutex();
            }
        }
        public string Read(string serviceName)
        {
            string readData = string.Empty;

            try
            {
                using (MemoryMappedFile mmf = MemoryMappedFile.OpenExisting(serviceName))
                {


                    //Mutex mutex = Mutex.OpenExisting("testmapmutex");
                    //mutex.WaitOne();

                    //using (MemoryMappedViewStream stream = mmf.CreateViewStream(1, 0))
                    //{
                    //    BinaryWriter writer = new BinaryWriter(stream);
                    //    writer.Write(0);
                    //}
                    //mutex.ReleaseMutex();


                    //MemoryMappedFile mmf = MemoryMappedFile.OpenExisting("MySharedMemory");
                    
                    
                    MemoryMappedViewStream mmfvs = mmf.CreateViewStream();

                    byte[] blen = new byte[4];

                    mmfvs.Read(blen, 0, 4);
                    string s1 = System.Text.Encoding.Default.GetString(blen);

                    int len = blen[0] + blen[1] * 256 + blen[2] * 65536 + blen[2] * 16777216;

                    byte[] strbuf = new byte[len];

                    mmfvs.Read(strbuf, 0, len);

                    string s = System.Text.Encoding.Default.GetString(strbuf);

                    Console.WriteLine(s);





                    //-------------------------------------------------------------------
                    //using (var accessor = mmf.CreateViewAccessor())
                    //{
                    //    int colorSize = Marshal.SizeOf(typeof(MyColor));
                    //    MyColor color;

                    //    // Make changes to the view.
                    //    for (long i = 0; i < length; i += colorSize)
                    //    {
                    //        accessor.Read(i, out color);
                    //        color.Brighten(10);
                    //        accessor.Write(i, ref color);
                    //    }
                    //}

                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Memory-mapped file does not exist. Run Process A first.");
            }

            //// MemoryMapTest로 이름붙인 공유 Memory 열기
            //var mappedFile = MemoryMappedFile.OpenExisting(serviceName, MemoryMappedFileRights.ReadWrite);
            //// 공유 Memory에서 읽은 것을 Stream으로 받기

            //using (Stream view = mappedFile.CreateViewStream())
            //{
            //    // stream을 String으로 변환
            //    view.Position = 0;

            //    using (StreamReader reader = new StreamReader(view, Encoding.UTF8))
            //    {
            //        // Data 읽어오기
            //        readData = reader.ReadToEnd();
            //    }

            //}

            return readData; 
        }
        public string Read2(string serviceName)
        {
            string readData = string.Empty;

            try
            {
                using (MemoryMappedFile mmf = MemoryMappedFile.OpenExisting(serviceName))
                {

                    Mutex mutex = Mutex.OpenExisting("testmapmutex");
                    mutex.WaitOne();

                    using (MemoryMappedViewStream stream = mmf.CreateViewStream(2, 0))
                    {
                        BinaryWriter writer = new BinaryWriter(stream);
                        writer.Write(1);
                    }
                    mutex.ReleaseMutex();
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Memory-mapped file does not exist. Run Process A first, then B.");
            }
            return readData; 
        }
        public void Write(string serviceName)
        {
            // Mapping된 file 가져오기
            MemoryMappedFile mapFile = MemoryMappedFile.OpenExisting(serviceName, MemoryMappedFileRights.ReadWrite);
            MemoryMappedViewAccessor accessor = mapFile.CreateViewAccessor();
            // 공유 Memory에 쓰기
            byte[] Buffer = ASCIIEncoding.ASCII.GetBytes("심S님" + "\0");
            accessor.WriteArray(0, Buffer, 0, Buffer.Length);
            accessor.Dispose();
            mapFile.Dispose();
        }
    
    }
}



