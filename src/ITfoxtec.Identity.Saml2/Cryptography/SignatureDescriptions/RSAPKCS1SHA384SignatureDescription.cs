﻿#if !NETFULL
using System;
using System.Security.Cryptography;

namespace ITfoxtec.Identity.Saml2.Cryptography
{
    public sealed class RSAPKCS1SHA384SignatureDescription : SignatureDescription
    {
        public RSAPKCS1SHA384SignatureDescription()
        {
            KeyAlgorithm = typeof(RSACryptoServiceProvider).AssemblyQualifiedName;
            DigestAlgorithm = typeof(SHA384Managed).AssemblyQualifiedName;
            FormatterAlgorithm = typeof(RSAPKCS1SignatureFormatter).AssemblyQualifiedName;
            DeformatterAlgorithm = typeof(RSAPKCS1SignatureDeformatter).AssemblyQualifiedName;
        }

        public override AsymmetricSignatureDeformatter CreateDeformatter(AsymmetricAlgorithm key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }

            RSAPKCS1SignatureDeformatter deformatter = new RSAPKCS1SignatureDeformatter(key);
            deformatter.SetHashAlgorithm("SHA384");
            return deformatter;
        }

        public override AsymmetricSignatureFormatter CreateFormatter(AsymmetricAlgorithm key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }

            RSAPKCS1SignatureFormatter formatter = new RSAPKCS1SignatureFormatter(key);
            formatter.SetHashAlgorithm("SHA384");
            return formatter;
        }
    }
}
#endif
