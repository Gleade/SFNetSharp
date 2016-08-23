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
        byte[] Buffer;
        int CurrentWritePos = 0;
        int CurrentReadPos = 0;

        /// <summary>
        /// Set the internal max buffer size.
        /// </summary>
        public static int MaxBufferSize { get; set; } = 1024;

        public Packet()
        {
            // Create a new memory stream and set it's max size
            MemoryStream = new MemoryStream();
            MemoryStream.SetLength(MaxBufferSize);
        }

        /// <summary>
        /// Create a packet 
        /// </summary>
        /// <param name="packet"></param>
        public Packet(byte[] bytes)
        {
            Buffer = bytes;

            if (BitConverter.IsLittleEndian)
                Array.Reverse(Buffer);
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
            CurrentReadPos = 0;
            CurrentWritePos = 0;
        }

        /// <summary>
        /// Write an unsigned byte to the buffer.
        /// </summary>
        /// <param name="value"></param>
        public void WriteByte(byte value)
        {
            byte[] b = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(b);
            MemoryStream.Write(b, CurrentWritePos, CurrentWritePos + b.Length);
            CurrentWritePos += b.Length;
        }

        /// <summary>
        /// Read an unsigned byte from the buffer.
        /// </summary>
        /// <returns></returns>
        public byte ReadByte()
        {
            return Buffer[CurrentReadPos];
        }

        /// <summary>
        /// Write a short to the buffer.
        /// </summary>
        /// <param name="value"></param>
        public void WriteShort(short value)
        {
            byte[] b = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(b);
            MemoryStream.Write(b, CurrentWritePos, CurrentWritePos + b.Length );
            CurrentWritePos += b.Length ;
        }

        /// <summary>
        /// Read a short from the buffer.
        /// </summary>
        /// <returns></returns>
        public short ReadShort()
        {
            short value = BitConverter.ToInt16(Buffer, CurrentReadPos);
            CurrentReadPos += sizeof(short);

            return value;
        }

        /// <summary>
        /// Write an unsigned short to the buffer.
        /// </summary>
        /// <param name="value"></param>
        public void WriteUShort(ushort value)
        {
            byte[] b = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(b);
            MemoryStream.Write(b, CurrentWritePos, b.Length - 1);
            CurrentWritePos += b.Length - 1;
        }

        /// <summary>
        /// Read an unsigned short from the buffer.
        /// </summary>
        /// <returns></returns>
        public ushort ReadUShort()
        {
            ushort value = BitConverter.ToUInt16(Buffer, CurrentReadPos);
            CurrentReadPos += sizeof(ushort);

            return value;
        }

        /// <summary>
        /// Write a signed integer to the buffer.
        /// </summary>
        /// <param name="value"></param>
        public void WriteInt(int value)
        {
            byte[] b = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(b);
            MemoryStream.Write(b, CurrentWritePos, b.Length);
            CurrentWritePos += b.Length;
        }
        /// <summary>
        /// Read an integer from the buffer.
        /// </summary>
        /// <returns></returns>
        public int ReadInt()
        {

            int value = BitConverter.ToInt32(Buffer, CurrentReadPos);
            CurrentReadPos += sizeof(int);
            return value;
        }

        /// <summary>
        /// Write an unsigned integer to the buffer.
        /// </summary>
        /// <param name="value"></param>
        public void WriteUInt(uint value)
        {
            byte[] b = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(b);
            MemoryStream.Write(b, CurrentWritePos, b.Length);
            CurrentWritePos += b.Length;
        }

        /// <summary>
        /// Read an unsigned integer from the buffer.
        /// </summary>
        public uint ReadUInt()
        {
            uint value = BitConverter.ToUInt32(Buffer, CurrentReadPos);
            CurrentReadPos += sizeof(uint);

            return value;
        }

        
        /// <summary>
        /// Read a float from the buffer.
        /// </summary>
        /// <returns></returns>
        public double ReadDouble()
        {
            double value = BitConverter.ToDouble(Buffer, CurrentReadPos);
            CurrentReadPos += sizeof(uint);

            return value;
        }

        /// <summary>
        /// Write a signed double to the buffer.
        /// </summary>
        /// <param name="value"></param>
        public void WriteDouble(double value)
        {
            byte[] b = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(b);
            MemoryStream.Write(b, CurrentWritePos, b.Length);
            CurrentWritePos += b.Length;
        }

        /// <summary>
        /// Get our byte buffer's data.
        /// </summary>
        /// <returns></returns>
        public byte [] GetBytes()
        {
            // Create a temp stream to store our bytes,
            // this will allow us to make the byte array as small as possible
            MemoryStream tempMemStream = new MemoryStream();
            tempMemStream.SetLength(CurrentWritePos);

            // Write all of the data from our memory stream into the temporary stream
            tempMemStream.Write(MemoryStream.ToArray(), 0, CurrentWritePos);

            // Return the total byte array
            return tempMemStream.ToArray();
            
        }

        /// <summary>
        /// Get the size of the buffer.
        /// </summary>
        /// <returns></returns>
        public int GetSize()
        {
            int size = CurrentWritePos + CurrentReadPos;
            return size;
        }
    }
}
