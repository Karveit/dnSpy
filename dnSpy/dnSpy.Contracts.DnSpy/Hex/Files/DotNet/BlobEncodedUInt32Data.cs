﻿/*
    Copyright (C) 2014-2018 de4dot@gmail.com

    This file is part of dnSpy

    dnSpy is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    dnSpy is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with dnSpy.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;

namespace dnSpy.Contracts.Hex.Files.DotNet {
	/// <summary>
	/// Compressed integer stored in #Blob and #US heaps
	/// </summary>
	public sealed class BlobEncodedUInt32Data : SimpleData {
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="span">Span of data</param>
		public BlobEncodedUInt32Data(HexBufferSpan span)
			: base(span) {
			if (span.IsEmpty || span.Length > 5)
				throw new ArgumentOutOfRangeException(nameof(span));
		}

		/// <summary>
		/// Writes the value
		/// </summary>
		/// <param name="formatter">Formatter</param>
		public override void WriteValue(HexFieldFormatter formatter) {
			var pos = Span.Span.Start;
			var value = Utils.ReadCompressedUInt32(Span.Buffer, ref pos);
			if (pos > Span.Span.End)
				formatter.WriteUnknownValue();
			else
				formatter.WriteUInt32(value);
		}
	}
}
