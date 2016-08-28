using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    class Packet
    {
        MemoryStream MemoryStream;
        BinaryWriter BinaryWriter;
        BinaryReader BinaryReader;
        byte[] Buffer;

        /// <summary>
        /// Set the internal max buffer size.
        /// </summary>
        public static int MaxBufferSize { get; set; } = 1024;

        public Packet()
        {
            // Create a new memory stream and set it's max size
            MemoryStream = new MemoryStream();
           // MemoryStream.SetLength(MaxBufferSize);

            BinaryWriter = new BinaryWriter(MemoryStream);
        }

        /// <summary>
        /// Create a packet 
        /// </summary>
        /// <param name="packet"></param>
        public Packet(byte[] bytes)
        {
            Buffer = bytes;
            MemoryStream = new MemoryStream();
            MemoryStream.Write(Buffer, 0, Buffer.Length);
            MemoryStream.Seek(0, SeekOrigin.Begin);
            BinaryReader = new BinaryReader(MemoryStream);

           
        }

        /// <summary>
        /// Clear the internal buffer.
        /// </summary>
        public void Clear()
        {
            if (MemoryStream != null)
            {
                MemoryStream.SetLength(0);
                MemoryStream.SetLength(MaxBufferSize);
                MemoryStream.Position = 0;
            }

            if (BinaryWriter != null)
            {
                BinaryWriter.Flush();
            }
        }

        /// <summary>
        /// Write an unsigned byte to the buffer.
        /// </summary>
        /// <param name="value"></param>
        public void WriteByte(byte value)
        {
            BinaryWriter.Write(value);
        }

        /// <summary>
        /// Read an unsigned byte from the buffer.
        /// </summary>
        /// <returns></returns>
        public byte ReadByte()
        {
            return BinaryReader.ReadByte();
        }

        /// <summary>
        /// Write a short to the buffer.
        /// </summary>
        /// <param name="value"></param>
        public void WriteShort(short value)
        {
            BinaryWriter.Write(value);
        }

        /// <summary>
        /// Read a short from the buffer.
        /// </summary>
        /// <returns></returns>
        public short ReadShort()
        {
            return BinaryReader.ReadInt16();
        }

        /// <summary>
        /// Write an unsigned short to the buffer.
        /// </summary>
        /// <param name="value"></param>
        public void WriteUShort(ushort value)
        {
            BinaryWriter.Write(value);
        }

        /// <summary>
        /// Read an unsigned short from the buffer.
        /// </summary>
        /// <returns></returns>
        public ushort ReadUShort()
        {

            return BinaryReader.ReadUInt16();
        }

        /// <summary>
        /// Write a signed integer to the buffer.
        /// </summary>
        /// <param name="value"></param>
        public void WriteInt(int value)
        {
            BinaryWriter.Write(value);
        }
        /// <summary>
        /// Read an integer from the buffer.
        /// </summary>
        /// <returns></returns>
        public int ReadInt()
        {
            return BinaryReader.ReadInt32();
        }

        /// <summary>
        /// Write an unsigned integer to the buffer.
        /// </summary>
        /// <param name="value"></param>
        public void WriteUInt(uint value)
        {
            BinaryWriter.Write(value);
        }

        /// <summary>
        /// Read an unsigned integer from the buffer.
        /// </summary>
        public uint ReadUInt()
        {
            return BinaryReader.ReadUInt32();
        }


        /// <summary>
        /// Write a signed double to the buffer.
        /// </summary>
        /// <param name="value"></param>
        public void WriteDouble(double value)
        {
            BinaryWriter.Write(value);
        }

        /// <summary>
        /// Read a double from the buffer.
        /// </summary>
        /// <returns></returns>
        public double ReadDouble()
        {

            return BinaryReader.ReadDouble();
        }

        /// <summary>
        /// Write a string to the  buffer.
        /// </summary>
        /// <param name="str"></param>
        public void WriteString(string str)
        {
            BinaryWriter.Write(str);
        }

        /// <summary>
        /// Read a string from the buffer.
        /// Requires knowing the length of the string to receive.
        /// </summary>
        /// <returns></returns>
        public string ReadString()
        {
            return BinaryReader.ReadString();
        }

        /// <summary>
        /// Get our byte buffer's data.
        /// </summary>
        /// <returns></returns>
        public byte [] GetBytes()
        {
           return MemoryStream.ToArray();
        }

        /// <summary>
        /// Get the size of the buffer.
        /// </summary>
        /// <returns></returns>
        public int GetSize()
        {
            return MemoryStream.ToArray().Length;
        }
    }
}
