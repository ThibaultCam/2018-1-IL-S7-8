using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ITI.Work
{
    public enum KrabouilleMode
    {
        /// <summary>
        /// Used to write krabouilled data to the inner stream.
        /// </summary>
        Krabouille,

        /// <summary>
        /// Used to read krabouilled data from inner stream.
        /// </summary>
        Unkrabouille
    }

    public class KrabouilleStream : Stream
    {
        Stream _inner;
        KrabouilleMode _mode;
        string _password;

        public KrabouilleStream( Stream inner, KrabouilleMode mode, string password )
        {
            _inner = inner;
            _mode = mode;
            _password = password;
        }

        public override bool CanRead { get; }
                                     
        public override bool CanSeek { get; }
                                     
        public override bool CanWrite { get; }

        public override long Length => throw new NotSupportedException();

        public override long Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void Flush()
        {
            _inner.Flush();
        }

        public override int Read( byte[] buffer, int offset, int count )
        {
            return _inner.Read( buffer, offset, count );
        }

        public override long Seek( long offset, SeekOrigin origin )
        {
            return _inner.Seek( offset, origin );
        }

        public override void SetLength( long value )
        {
            _inner.SetLength( value );
        }

        public override void Write( byte[] buffer, int offset, int count )
        {
            _inner.Write( buffer, offset, count );
        }
    }
}
