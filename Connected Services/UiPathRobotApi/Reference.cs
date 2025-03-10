﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmartG.UiPathRobotApi {
    using System.Runtime.Serialization;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SettingsName", Namespace="http://schemas.datacontract.org/2004/07/UiPath.Models")]
    public enum SettingsName : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        NuGetApiKey = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        NuGetServerUrl = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ActivitiesFeed = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        UiPathServerUrl = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        TracingLevel = 4,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        LowLevelTracing = 5,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        RobotKey = 6,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        LoginToConsole = 7,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ResolutionWidth = 8,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ResolutionHeight = 9,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ResolutionDepth = 10,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ConnectionString = 11,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UiPathRobotApi.IUiPathRemoteContract")]
    public interface IUiPathRemoteContract {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUiPathRemoteContract/StartJob", ReplyAction="http://tempuri.org/IUiPathRemoteContract/StartJobResponse")]
        string StartJob(System.IO.Stream jobInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUiPathRemoteContract/StartJob", ReplyAction="http://tempuri.org/IUiPathRemoteContract/StartJobResponse")]
        System.Threading.Tasks.Task<string> StartJobAsync(System.IO.Stream jobInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUiPathRemoteContract/QueryJob", ReplyAction="http://tempuri.org/IUiPathRemoteContract/QueryJobResponse")]
        string QueryJob(string jobId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUiPathRemoteContract/QueryJob", ReplyAction="http://tempuri.org/IUiPathRemoteContract/QueryJobResponse")]
        System.Threading.Tasks.Task<string> QueryJobAsync(string jobId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IUiPathRemoteContract/CancelJob")]
        void CancelJob(string jobId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IUiPathRemoteContract/CancelJob")]
        System.Threading.Tasks.Task CancelJobAsync(string jobId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUiPathRemoteContract/IsAlive", ReplyAction="http://tempuri.org/IUiPathRemoteContract/IsAliveResponse")]
        bool IsAlive();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUiPathRemoteContract/IsAlive", ReplyAction="http://tempuri.org/IUiPathRemoteContract/IsAliveResponse")]
        System.Threading.Tasks.Task<bool> IsAliveAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUiPathRemoteContract/ListJobs", ReplyAction="http://tempuri.org/IUiPathRemoteContract/ListJobsResponse")]
        string ListJobs();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUiPathRemoteContract/ListJobs", ReplyAction="http://tempuri.org/IUiPathRemoteContract/ListJobsResponse")]
        System.Threading.Tasks.Task<string> ListJobsAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IUiPathRemoteContract/RemoveJob")]
        void RemoveJob(string jobId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IUiPathRemoteContract/RemoveJob")]
        System.Threading.Tasks.Task RemoveJobAsync(string jobId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUiPathRemoteContractChannel : SmartG.UiPathRobotApi.IUiPathRemoteContract, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UiPathRemoteContractClient : System.ServiceModel.ClientBase<SmartG.UiPathRobotApi.IUiPathRemoteContract>, SmartG.UiPathRobotApi.IUiPathRemoteContract {
        
        public UiPathRemoteContractClient() {
        }
        
        public UiPathRemoteContractClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UiPathRemoteContractClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UiPathRemoteContractClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UiPathRemoteContractClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string StartJob(System.IO.Stream jobInfo) {
            return base.Channel.StartJob(jobInfo);
        }
        
        public System.Threading.Tasks.Task<string> StartJobAsync(System.IO.Stream jobInfo) {
            return base.Channel.StartJobAsync(jobInfo);
        }
        
        public string QueryJob(string jobId) {
            return base.Channel.QueryJob(jobId);
        }
        
        public System.Threading.Tasks.Task<string> QueryJobAsync(string jobId) {
            return base.Channel.QueryJobAsync(jobId);
        }
        
        public void CancelJob(string jobId) {
            base.Channel.CancelJob(jobId);
        }
        
        public System.Threading.Tasks.Task CancelJobAsync(string jobId) {
            return base.Channel.CancelJobAsync(jobId);
        }
        
        public bool IsAlive() {
            return base.Channel.IsAlive();
        }
        
        public System.Threading.Tasks.Task<bool> IsAliveAsync() {
            return base.Channel.IsAliveAsync();
        }
        
        public string ListJobs() {
            return base.Channel.ListJobs();
        }
        
        public System.Threading.Tasks.Task<string> ListJobsAsync() {
            return base.Channel.ListJobsAsync();
        }
        
        public void RemoveJob(string jobId) {
            base.Channel.RemoveJob(jobId);
        }
        
        public System.Threading.Tasks.Task RemoveJobAsync(string jobId) {
            return base.Channel.RemoveJobAsync(jobId);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UiPathRobotApi.IUiPathRemoteDuplexContract", CallbackContract=typeof(SmartG.UiPathRobotApi.IUiPathRemoteDuplexContractCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface IUiPathRemoteDuplexContract {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUiPathRemoteContract/StartJob", ReplyAction="http://tempuri.org/IUiPathRemoteContract/StartJobResponse")]
        string StartJob(System.IO.Stream jobInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUiPathRemoteContract/StartJob", ReplyAction="http://tempuri.org/IUiPathRemoteContract/StartJobResponse")]
        System.Threading.Tasks.Task<string> StartJobAsync(System.IO.Stream jobInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUiPathRemoteContract/QueryJob", ReplyAction="http://tempuri.org/IUiPathRemoteContract/QueryJobResponse")]
        string QueryJob(string jobId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUiPathRemoteContract/QueryJob", ReplyAction="http://tempuri.org/IUiPathRemoteContract/QueryJobResponse")]
        System.Threading.Tasks.Task<string> QueryJobAsync(string jobId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IUiPathRemoteContract/CancelJob")]
        void CancelJob(string jobId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IUiPathRemoteContract/CancelJob")]
        System.Threading.Tasks.Task CancelJobAsync(string jobId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUiPathRemoteContract/IsAlive", ReplyAction="http://tempuri.org/IUiPathRemoteContract/IsAliveResponse")]
        bool IsAlive();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUiPathRemoteContract/IsAlive", ReplyAction="http://tempuri.org/IUiPathRemoteContract/IsAliveResponse")]
        System.Threading.Tasks.Task<bool> IsAliveAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUiPathRemoteContract/ListJobs", ReplyAction="http://tempuri.org/IUiPathRemoteContract/ListJobsResponse")]
        string ListJobs();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUiPathRemoteContract/ListJobs", ReplyAction="http://tempuri.org/IUiPathRemoteContract/ListJobsResponse")]
        System.Threading.Tasks.Task<string> ListJobsAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IUiPathRemoteContract/RemoveJob")]
        void RemoveJob(string jobId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IUiPathRemoteContract/RemoveJob")]
        System.Threading.Tasks.Task RemoveJobAsync(string jobId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IUiPathRemoteDuplexContract/ResumeJob")]
        void ResumeJob(string jobId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IUiPathRemoteDuplexContract/ResumeJob")]
        System.Threading.Tasks.Task ResumeJobAsync(string jobId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUiPathRemoteDuplexContract/CanConnectToServer", ReplyAction="http://tempuri.org/IUiPathRemoteDuplexContract/CanConnectToServerResponse")]
        bool CanConnectToServer();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUiPathRemoteDuplexContract/CanConnectToServer", ReplyAction="http://tempuri.org/IUiPathRemoteDuplexContract/CanConnectToServerResponse")]
        System.Threading.Tasks.Task<bool> CanConnectToServerAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUiPathRemoteDuplexContract/ConnectToServer", ReplyAction="http://tempuri.org/IUiPathRemoteDuplexContract/ConnectToServerResponse")]
        void ConnectToServer(string jsonConnectionInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUiPathRemoteDuplexContract/ConnectToServer", ReplyAction="http://tempuri.org/IUiPathRemoteDuplexContract/ConnectToServerResponse")]
        System.Threading.Tasks.Task ConnectToServerAsync(string jsonConnectionInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUiPathRemoteDuplexContract/DisconnectFromServer", ReplyAction="http://tempuri.org/IUiPathRemoteDuplexContract/DisconnectFromServerResponse")]
        void DisconnectFromServer();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUiPathRemoteDuplexContract/DisconnectFromServer", ReplyAction="http://tempuri.org/IUiPathRemoteDuplexContract/DisconnectFromServerResponse")]
        System.Threading.Tasks.Task DisconnectFromServerAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUiPathRemoteDuplexContract/GetServiceState", ReplyAction="http://tempuri.org/IUiPathRemoteDuplexContract/GetServiceStateResponse")]
        string GetServiceState();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUiPathRemoteDuplexContract/GetServiceState", ReplyAction="http://tempuri.org/IUiPathRemoteDuplexContract/GetServiceStateResponse")]
        System.Threading.Tasks.Task<string> GetServiceStateAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUiPathRemoteDuplexContract/GetAssociatedProcesses", ReplyAction="http://tempuri.org/IUiPathRemoteDuplexContract/GetAssociatedProcessesResponse")]
        string GetAssociatedProcesses();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUiPathRemoteDuplexContract/GetAssociatedProcesses", ReplyAction="http://tempuri.org/IUiPathRemoteDuplexContract/GetAssociatedProcessesResponse")]
        System.Threading.Tasks.Task<string> GetAssociatedProcessesAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IUiPathRemoteDuplexContract/InstallPackage")]
        void InstallPackage(string packageId, string packageVersion);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IUiPathRemoteDuplexContract/InstallPackage")]
        System.Threading.Tasks.Task InstallPackageAsync(string packageId, string packageVersion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUiPathRemoteDuplexContract/GetSettingValue", ReplyAction="http://tempuri.org/IUiPathRemoteDuplexContract/GetSettingValueResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(byte[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(SmartG.UiPathRobotApi.SettingsName))]
        object GetSettingValue(SmartG.UiPathRobotApi.SettingsName settingName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUiPathRemoteDuplexContract/GetSettingValue", ReplyAction="http://tempuri.org/IUiPathRemoteDuplexContract/GetSettingValueResponse")]
        System.Threading.Tasks.Task<object> GetSettingValueAsync(SmartG.UiPathRobotApi.SettingsName settingName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUiPathRemoteDuplexContract/SetSettingValue", ReplyAction="http://tempuri.org/IUiPathRemoteDuplexContract/SetSettingValueResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(byte[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(SmartG.UiPathRobotApi.SettingsName))]
        void SetSettingValue(SmartG.UiPathRobotApi.SettingsName settingName, object settingValue);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUiPathRemoteDuplexContract/SetSettingValue", ReplyAction="http://tempuri.org/IUiPathRemoteDuplexContract/SetSettingValueResponse")]
        System.Threading.Tasks.Task SetSettingValueAsync(SmartG.UiPathRobotApi.SettingsName settingName, object settingValue);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUiPathRemoteDuplexContractCallback {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUiPathRemoteDuplexContract/OnJobCompleted", ReplyAction="http://tempuri.org/IUiPathRemoteDuplexContract/OnJobCompletedResponse")]
        void OnJobCompleted(string invokeCompletedInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUiPathRemoteDuplexContract/OnTrackReceived", ReplyAction="http://tempuri.org/IUiPathRemoteDuplexContract/OnTrackReceivedResponse")]
        bool OnTrackReceived(string trackRecord);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IUiPathRemoteDuplexContract/OnLog")]
        void OnLog(string LogMessage);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUiPathRemoteDuplexContract/OnPackagesUpdated", ReplyAction="http://tempuri.org/IUiPathRemoteDuplexContract/OnPackagesUpdatedResponse")]
        void OnPackagesUpdated();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUiPathRemoteDuplexContractChannel : SmartG.UiPathRobotApi.IUiPathRemoteDuplexContract, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UiPathRemoteDuplexContractClient : System.ServiceModel.DuplexClientBase<SmartG.UiPathRobotApi.IUiPathRemoteDuplexContract>, SmartG.UiPathRobotApi.IUiPathRemoteDuplexContract {
        
        public UiPathRemoteDuplexContractClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public UiPathRemoteDuplexContractClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public UiPathRemoteDuplexContractClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public UiPathRemoteDuplexContractClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public UiPathRemoteDuplexContractClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public string StartJob(System.IO.Stream jobInfo) {
            return base.Channel.StartJob(jobInfo);
        }
        
        public System.Threading.Tasks.Task<string> StartJobAsync(System.IO.Stream jobInfo) {
            return base.Channel.StartJobAsync(jobInfo);
        }
        
        public string QueryJob(string jobId) {
            return base.Channel.QueryJob(jobId);
        }
        
        public System.Threading.Tasks.Task<string> QueryJobAsync(string jobId) {
            return base.Channel.QueryJobAsync(jobId);
        }
        
        public void CancelJob(string jobId) {
            base.Channel.CancelJob(jobId);
        }
        
        public System.Threading.Tasks.Task CancelJobAsync(string jobId) {
            return base.Channel.CancelJobAsync(jobId);
        }
        
        public bool IsAlive() {
            return base.Channel.IsAlive();
        }
        
        public System.Threading.Tasks.Task<bool> IsAliveAsync() {
            return base.Channel.IsAliveAsync();
        }
        
        public string ListJobs() {
            return base.Channel.ListJobs();
        }
        
        public System.Threading.Tasks.Task<string> ListJobsAsync() {
            return base.Channel.ListJobsAsync();
        }
        
        public void RemoveJob(string jobId) {
            base.Channel.RemoveJob(jobId);
        }
        
        public System.Threading.Tasks.Task RemoveJobAsync(string jobId) {
            return base.Channel.RemoveJobAsync(jobId);
        }
        
        public void ResumeJob(string jobId) {
            base.Channel.ResumeJob(jobId);
        }
        
        public System.Threading.Tasks.Task ResumeJobAsync(string jobId) {
            return base.Channel.ResumeJobAsync(jobId);
        }
        
        public bool CanConnectToServer() {
            return base.Channel.CanConnectToServer();
        }
        
        public System.Threading.Tasks.Task<bool> CanConnectToServerAsync() {
            return base.Channel.CanConnectToServerAsync();
        }
        
        public void ConnectToServer(string jsonConnectionInfo) {
            base.Channel.ConnectToServer(jsonConnectionInfo);
        }
        
        public System.Threading.Tasks.Task ConnectToServerAsync(string jsonConnectionInfo) {
            return base.Channel.ConnectToServerAsync(jsonConnectionInfo);
        }
        
        public void DisconnectFromServer() {
            base.Channel.DisconnectFromServer();
        }
        
        public System.Threading.Tasks.Task DisconnectFromServerAsync() {
            return base.Channel.DisconnectFromServerAsync();
        }
        
        public string GetServiceState() {
            return base.Channel.GetServiceState();
        }
        
        public System.Threading.Tasks.Task<string> GetServiceStateAsync() {
            return base.Channel.GetServiceStateAsync();
        }
        
        public string GetAssociatedProcesses() {
            return base.Channel.GetAssociatedProcesses();
        }
        
        public System.Threading.Tasks.Task<string> GetAssociatedProcessesAsync() {
            return base.Channel.GetAssociatedProcessesAsync();
        }
        
        public void InstallPackage(string packageId, string packageVersion) {
            base.Channel.InstallPackage(packageId, packageVersion);
        }
        
        public System.Threading.Tasks.Task InstallPackageAsync(string packageId, string packageVersion) {
            return base.Channel.InstallPackageAsync(packageId, packageVersion);
        }
        
        public object GetSettingValue(SmartG.UiPathRobotApi.SettingsName settingName) {
            return base.Channel.GetSettingValue(settingName);
        }
        
        public System.Threading.Tasks.Task<object> GetSettingValueAsync(SmartG.UiPathRobotApi.SettingsName settingName) {
            return base.Channel.GetSettingValueAsync(settingName);
        }
        
        public void SetSettingValue(SmartG.UiPathRobotApi.SettingsName settingName, object settingValue) {
            base.Channel.SetSettingValue(settingName, settingValue);
        }
        
        public System.Threading.Tasks.Task SetSettingValueAsync(SmartG.UiPathRobotApi.SettingsName settingName, object settingValue) {
            return base.Channel.SetSettingValueAsync(settingName, settingValue);
        }
    }
}
