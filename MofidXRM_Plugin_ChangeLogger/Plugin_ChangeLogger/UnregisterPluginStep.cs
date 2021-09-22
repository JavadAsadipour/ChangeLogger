
// <copyright file="UnregisterPluginStep.cs" company="">
// Copyright (c) 2021 All Rights Reserved
// </copyright>
// <author></author>
// <date>9/21/2021 5:32:08 PM</date>
// <summary>Implements the UnregisterPluginStep Plugin.</summary>
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
// </auto-generated>

using System;
using System.ServiceModel;
using Microsoft.Xrm.Sdk;

namespace MofidXRM_Plugin_ChangeLogger.Plugin_ChangeLogger
{

    /// <summary>
    /// UnregisterPluginStep Plugin.
    /// </summary>    
    public class UnregisterPluginStep: PluginBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnregisterPluginStep"/> class.
        /// </summary>
        /// <param name="unsecure">Contains public (unsecured) configuration information.</param>
        /// <param name="secure">Contains non-public (secured) configuration information. 
        /// When using Microsoft Dynamics 365 for Outlook with Offline Access, 
        /// the secure string is not passed to a plug-in that executes while the client is offline.</param>
        public UnregisterPluginStep(string unsecure, string secure)
            : base(typeof(UnregisterPluginStep))
        {
            
           // TODO: Implement your custom configuration handling.
        }


        /// <summary>
        /// Main entry point for he business logic that the plug-in is to execute.
        /// </summary>
        /// <param name="localContext">The <see cref="LocalPluginContext"/> which contains the
        /// <see cref="IPluginExecutionContext"/>,
        /// <see cref="IOrganizationService"/>
        /// and <see cref="ITracingService"/>
        /// </param>
        /// <remarks>
        /// For improved performance, Microsoft Dynamics 365 caches plug-in instances.
        /// The plug-in's Execute method should be written to be stateless as the constructor
        /// is not called for every invocation of the plug-in. Also, multiple system threads
        /// could execute the plug-in at the same time. All per invocation state information
        /// is stored in the context. This means that you should not use global variables in plug-ins.
        /// </remarks>
        protected override void ExecuteCrmPlugin(LocalPluginContext localContext)
        {
            if (localContext == null)
            {
                throw new InvalidPluginExecutionException("localContext");
            }

            IPluginExecutionContext context = localContext.PluginExecutionContext;
            IOrganizationService service = localContext.OrganizationService;

            EntityReference target = (EntityReference)context.InputParameters["Target"];
            Entity changelogconfiguration = service.Retrieve(target.LogicalName, target.Id, new Microsoft.Xrm.Sdk.Query.ColumnSet(true));

            service.Delete("sdkmessageprocessingstep", new Guid(changelogconfiguration["ms_sdkmessageprocessingstepid"].ToString()));
        }
    }
}
