using System;
using System.Runtime.InteropServices;

namespace EarTrumpet.Interop.MMDeviceAPI
{
    [ComImport]
    [Guid("870AF99C-171D-4F9E-AF0D-E63DF40C2BC9")]
    public class PolicyConfigClient { }

    public class AutoPolicyConfigClientWin7
    {
        IPolicyConfigWin7 _policyClient = (IPolicyConfigWin7)new PolicyConfigClient();

        public void SetEndpointVisibility(string deviceId, bool isVisible)
        {
            _policyClient.SetEndpointVisibility(deviceId, isVisible ? (short)1 : (short)0);
        }

        public void SetDefaultEndpoint(string deviceId, ERole role = ERole.eMultimedia)
        {
            _policyClient.SetDefaultEndpoint(deviceId, role);
        }

        public void GetPropertyValue(string deviceId, bool fx, Guid formatId, uint propertyId, ref PropVariant value) {

            var key = new PROPERTYKEY() {
                fmtid = formatId,
                pid = (UIntPtr)propertyId
            };
            _policyClient.GetPropertyValue(deviceId, fx, ref key, ref value);
        }

        internal void SetPropertyValue(string deviceId, bool fx, Guid formatId, uint propertyId, PropVariant value) {
            var key = new PROPERTYKEY() {
                fmtid = formatId,
                pid = (UIntPtr)propertyId
            };
            _policyClient.SetPropertyValue(deviceId, fx, ref key, ref value);
        }
    }
}
