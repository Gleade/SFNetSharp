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
        int CurrentWritePos = 0;
        int CurrentReadPos = 0;

        /// <summary>
        /// Set the internal max buffer size.
        /// </summary>
        public int MaxBufferSize { get; set; } = 1024;

        public Packet()
        {
            // Create a new memory stream and set it's max size
            MemoryStream = new MemoryStream();
            MemoryStream.SetLength(MaxBufferSize);
        }

        public void Clear()
        {
            MemoryStream.SetLength(0);
            MemoryStream.SetLength(MaxBufferSize);
            MemoryStream.Position = 0;
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
            MemoryStream.Write(b, CurrentWritePos, b.Length);
            CurrentWritePos += b.Length;
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
            MemoryStream.Write(b, CurrentWritePos, b.Length);
            CurrentWritePos += b.Length;
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
            MemoryStream.Write(b, CurrentWritePos, b.Length);
            CurrentWritePos += b.Length;
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
        /// Write a signed float to the buffer.
        /// </summary>
        /// <param name="value"></param>
        public void WriteFloat(float value)
        {
            byte[] b = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(b);
            MemoryStream.Write(b, CurrentWritePos, b.Length);
            CurrentWritePos += b.Length;
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
