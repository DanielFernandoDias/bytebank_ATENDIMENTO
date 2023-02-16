using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bytebank_ATENDIMENTO.bytebank.Exceptions
{

	[Serializable]
	public class ByteBanckException : Exception
	{
		public ByteBanckException() { }
		public ByteBanckException(string message) : base("Aconteceu uma excessão ==> " + message) { }
		public ByteBanckException(string message, Exception inner) : base(message, inner) { }
		protected ByteBanckException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
