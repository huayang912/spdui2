/*
 * CSV I/O Library.NET
 * Copyright (C) 2005, uguu All rights reserved.
 * 
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions
 * are met:
 * 
 *  - Redistributions of source code must retain the above copyright
 *    notice, this list of conditions and the following disclaimer.
 * 
 *  - Redistributions in binary form must reproduce the above copyright
 *    notice, this list of conditions and the following disclaimer in the
 *    documentation and/or other materials provided with the distribution.
 * 
 * THIS SOFTWARE IS PROVIDED BY THE AUTHOR ``AS IS'' AND ANY EXPRESS OR
 * IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED.  IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY DIRECT,
 * INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 * (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
 * SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION)
 * HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT,
 * STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN
 * ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
 * POSSIBILITY OF SUCH DAMAGE.
 */

using System;
using System.Data;
using System.IO;

namespace Dndp.Utility.CSV
{
    /// <summary>
    ///     <see cref="TextWriter"/> インスタンスに CSV 侘塀のデ�`タを竃薦します。
    /// </summary>
    /// <remarks>
    ///     インスタンスの恬撹�rに峺協した個佩猟忖、曝俳り猟忖を聞喘して CSV デ�`タを竃薦します。
    ///     竃薦する�､妨槻侘鍔屐�曝俳り猟忖、ダブルクォ�`テ�`ションが根まれる��栽、エスケ�`プして竃薦します。
    ///     null 歌孚や <see cref="DBNull.Value"/> �､録嬶鍔崛个箸靴導�薦します。
    /// </remarks>
    public sealed class CSVWriter : IDisposable
    {
        /// <summary>
        ///     竃薦枠ライタ�`。
        /// </summary>
        private TextWriter writer;
        /// <summary>
        ///     個佩猟忖。
        /// </summary>
        private string newLine;
        /// <summary>
        ///     曝俳り猟忖。
        /// </summary>
        private string delimiter;
        /// <summary>
        ///     竃薦双了崔を燕すインデックス桑催。
        /// </summary>
        private int columnIndex = 0;
        /// <summary>
        ///     竃薦佩了崔を燕すインデックス桑催。
        /// </summary>
        private int rowIndex = 0;
        /// <summary>
        ///     峺協した <see cref="TextWriter"/> インスタンスに CSV 侘塀のデ�`タを竃薦する、
        ///     <see cref="CSVWriter"/> クラスの仟しいインスタンスを兜豚晒します。
        ///     個佩猟忖は <see cref="Environment.NewLine"/> 、曝俳り猟忖は "," になります。
        /// </summary>
        /// <param name="writer">竃薦枠ライタ�`。</param>
        /// <exception cref="ArgumentNullException"><paramref name="writer"/> 哈方が null 歌孚の��栽。</exception>
        public CSVWriter(TextWriter writer)
            : this(writer, Environment.NewLine, ",")
        {
        }
        /// <summary>
        ///     峺協した <see cref="TextWriter"/> インスタンスに峺協した個佩猟忖と曝俳り猟忖で CSV 侘塀のデ�`タを竃薦する、
        ///     <see cref="CSVWriter"/> クラスの仟しいインスタンスを兜豚晒します。
        /// </summary>
        /// <param name="writer">竃薦枠ライタ�`。</param>
        /// <param name="newLine">個佩猟忖。</param>
        /// <param name="delimiter">曝俳り猟忖。</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="writer"/> 哈方が null 歌孚の��栽。
        ///     <paramref name="newLine"/> 哈方、 <paramref name="delimiter"/> 哈方が null 歌孚か腎猟忖双の��栽。
        /// </exception>
        public CSVWriter(TextWriter writer, string newLine, string delimiter)
        {
            // 秘薦をチェックします。
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }
            if (newLine == null || newLine == string.Empty)
            {
                throw new ArgumentNullException("newLine");
            }
            if (delimiter == null || delimiter == string.Empty)
            {
                throw new ArgumentNullException("delimiter");
            }
            // 兜豚晒します。
            this.writer = writer;
            this.newLine = newLine;
            this.delimiter = delimiter;
        }
        /// <summary>
        ///     <see cref="CSVWriter"/> インスタンスを�]じます。
        ///     竃薦枠ライタ�`も�]じます。
        /// </summary>
        public void Close()
        {
            if (this.writer != null)
            {
                this.writer.Close();
                this.writer = null;
            }
        }
        /// <summary>
        ///     <see cref="CSVWriter"/> インスタンスを�]じます。
        ///     竃薦枠ライタ�`も�]じます。
        /// </summary>
        public void Dispose()
        {
            if (this.writer != null)
            {
                this.writer.Close();
                this.writer = null;
            }
        }
        /// <summary>
        ///     <see cref="CSVWriter"/> インスタンスが�]じているかどうかを函誼します。
        /// </summary>
        public bool IsClosed
        {
            get
            {
                return (this.writer == null);
            }
        }
        /// <summary>
        ///     �F壓の竃薦双了崔を燕すインデックス桑催を函誼します。
        /// </summary>
        /// <remarks>
        ///     兜豚�ﾖ堰瓩領志辰� 0 です。
        /// </remarks>
        public int ColumnIndex
        {
            get
            {
                return this.columnIndex;
            }
        }
        /// <summary>
        ///     �F壓の竃薦佩了崔を燕すインデックス桑催を函誼します。
        /// </summary>
        /// <remarks>
        ///     兜豚�ﾖ堰瓩領志辰� 0 です。
        /// </remarks>
        public int RowIndex
        {
            get
            {
                return this.rowIndex;
            }
        }
        /// <summary>
        ///     �g匯の�､魍�薦します。
        /// </summary>
        /// <param name="value">竃薦する�｡�</param>
        /// <exception cref="ObjectDisposedException"><see cref="CSVWriter"/> インスタンスが屡に�]じている��栽。</exception>
        public void Write(string value)
        {
            // インスタンスの彜�Bをチェックします。
            if (this.IsClosed)
            {
                throw new ObjectDisposedException("writer");
            }

            // 竃薦します。
            string v = "";
            if (value == null)
            {
                value = string.Empty;
            }
            if (value.IndexOf(this.newLine) != -1 || value.IndexOf(this.delimiter) != -1)
            {
                v += value.Replace("\"", "\"\"");
                v = "\"" + v + "\"";
            }
            else
            {
                v += value;
            }
            if (this.columnIndex > 0)
            {
                v = this.delimiter + v;
            }
            this.writer.Write(v);
            this.columnIndex++;
        }
        /// <summary>
        ///     個佩します。
        /// </summary>
        /// <exception cref="ObjectDisposedException"><see cref="CSVWriter"/> インスタンスが屡に�]じている��栽。</exception>
        public void WriteNewLine()
        {
            // インスタンスの彜�Bをチェックします。
            if (this.IsClosed)
            {
                throw new ObjectDisposedException("writer");
            }

            // 竃薦します。
            this.writer.Write(this.newLine);
            this.columnIndex = 0;
            this.rowIndex++;
        }
        /// <summary>
        ///     �}方の�､鰡B�Aして竃薦します。
        /// </summary>
        /// <param name="values">竃薦する�､療篩弌�</param>
        /// <exception cref="ArgumentNullException"><paramref name="values"/> 哈方が null 歌孚の��栽。</exception>
        /// <exception cref="ObjectDisposedException"><see cref="CSVWriter"/> インスタンスが屡に�]じている��栽。</exception>
        public void Write(string[] values)
        {
            // 秘薦をチェックします。
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }
            // 竃薦します。
            foreach (string value in values)
            {
                this.Write(value);
            }
        }
        /// <summary>
        ///     �}方の�､鰡B�Aして竃薦します。
        /// </summary>
        /// <param name="values">竃薦する�､龍�肝圷塘双。</param>
        /// <exception cref="ArgumentNullException"><paramref name="values"/> 哈方が null 歌孚の��栽。</exception>
        /// <exception cref="ObjectDisposedException"><see cref="CSVWriter"/> インスタンスが屡に�]じている��栽。</exception>
        /// <remarks>
        ///     <see cref="Write(string[])"/> メソッドは�}方の�､鰡B�Aして竃薦しますが、 <see cref="Write(string[][])"/> メソッドは�}方佩を竃薦します。
        ///     竃薦は駅ず仟しい佩から兵まります。
        ///     屡に採らかの�､�竃薦されている��栽、個佩してから竃薦を�_兵します。
        ///     匯佩ごとに (輝隼ですが) 個佩します。
        ///     恷瘁の佩も個佩します。
        ///     したがって、畠ての竃薦が頼阻すると、竃薦了崔は仟しい佩の枠�^になります。
        /// </remarks>
        public void Write(string[][] values)
        {
            // 秘薦をチェックします。
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }
            foreach (string[] line in values)
            {
                if (line == null)
                {
                    throw new ArgumentNullException("values");
                }
            }
            // 竃薦します。
            if (this.columnIndex > 0)
            {
                this.WriteNewLine();
            }
            foreach (string[] line in values)
            {
                foreach (string value in line)
                {
                    this.Write(value);
                }
                this.WriteNewLine();
            }
        }
        /// <summary>
        ///     リ�`ダ�`から�､鰌iみ�zみ、畠て竃薦します。
        /// </summary>
        /// <param name="dataReader">�､燐iみ�zみ圷リ�`ダ�`。</param>
        /// <exception cref="ArgumentNullException"><paramref name="dataReader"/> 哈方が null 歌孚の��栽。</exception>
        /// <exception cref="ObjectDisposedException"><see cref="CSVWriter"/> インスタンスが屡に�]じている��栽。</exception>
        /// <remarks>
        ///     <see cref="IDataReader"/> インスタンスから畠ての双の�､鯣ゝ辰掘�畠ての佩を竃薦します。
        ///     竃薦は駅ず仟しい佩から兵まります。
        ///     屡に採らかの�､�竃薦されている��栽、個佩してから竃薦を�_兵します。
        ///     匯佩ごとに (輝隼ですが) 個佩します。
        ///     恷瘁の佩も個佩します。
        ///     したがって、畠ての竃薦が頼阻すると、竃薦了崔は仟しい佩の枠�^になります。
        ///     畠ての竃薦が頼阻しても <see cref="IDataReader"/> インスタンスは�]じられません。
        /// </remarks>
        public void Write(IDataReader dataReader)
        {
            this.Write(dataReader, null, int.MaxValue);
        }
        /// <summary>
        ///     リ�`ダ�`から�､鰌iみ�zみ、峺協した双、式び佩方を竃薦します。
        /// </summary>
        /// <param name="dataReader">�､燐iみ�zみ圷リ�`ダ�`。</param>
        /// <param name="names">
        ///     竃薦する双兆の塘双。
        ///     畠ての双を竃薦する��栽は null 歌孚を峺協することができます。
        /// </param>
        /// <param name="count">竃薦する佩方。</param>
        /// <exception cref="ArgumentNullException"><paramref name="dataReader"/> 哈方が null 歌孚の��栽。</exception>
        /// <exception cref="ArgumentException"><paramref name="count"/> 哈方が 0 隆�困���栽。</exception>
        /// <remarks>
        ///     <see cref="IDataReader"/> インスタンスから峺協した��桑で双の�､鯣ゝ辰掘�峺協した佩方の佩を竃薦します。
        ///     竃薦は駅ず仟しい佩から兵まります。
        ///     屡に採らかの�､�竃薦されている��栽、個佩してから竃薦を�_兵します。
        ///     匯佩ごとに (輝隼ですが) 個佩します。
        ///     恷瘁の佩も個佩します。
        ///     したがって、畠ての竃薦が頼阻すると、竃薦了崔は仟しい佩の枠�^になります。
        ///     畠ての竃薦が頼阻しても <see cref="IDataReader"/> インスタンスは�]じられません。
        /// </remarks>
        public void Write(IDataReader dataReader, string[] names, int count)
        {
            // 秘薦をチェックします。
            if (dataReader == null)
            {
                throw new ArgumentNullException("dataReader");
            }
            if (count < 0)
            {
                throw new ArgumentException("count 哈方が 0 隆�困任后�");
            }
            // 竃薦します。
            if (this.columnIndex > 0)
            {
                this.WriteNewLine();
            }
            for (int row = 0; row < count; row++)
            {
                if (!dataReader.Read())
                {
                    break;
                }
                object[] values = null;
                if (names != null)
                {
                    values = new object[names.Length];
                    for (int nameIndex = 0; nameIndex < names.Length; nameIndex++)
                    {
                        values[nameIndex] = dataReader[names[nameIndex]];
                    }
                }
                else
                {
                    values = new object[dataReader.FieldCount];
                    dataReader.GetValues(values);
                }
                foreach (object value in values)
                {
                    if (value == DBNull.Value)
                    {
                        this.Write(string.Empty);
                    }
                    else if (value == null)
                    {
                        this.Write(string.Empty);
                    }
                    else
                    {
                        this.Write(value.ToString());
                    }
                }
                this.WriteNewLine();
            }
        }
    }
}