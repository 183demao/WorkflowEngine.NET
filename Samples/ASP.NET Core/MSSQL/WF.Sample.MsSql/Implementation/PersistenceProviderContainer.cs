﻿using Microsoft.Extensions.Configuration;
using OptimaJet.Workflow.Core.Generator;
using OptimaJet.Workflow.Core.Persistence;
using OptimaJet.Workflow.DbPersistence;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WF.Sample.Business.DataAccess;

namespace WF.Sample.MsSql.Implementation
{
    public class PersistenceProviderContainer : IPersistenceProviderContainer
    {
        public PersistenceProviderContainer(IConfiguration config)
        {
            _provider = new MSSQLProvider(config.GetConnectionString("DefaultConnection"));
        }

        private readonly MSSQLProvider _provider;

        public IPersistenceProvider AsPersistenceProvider => _provider;

        public ISchemePersistenceProvider<XElement> AsSchemePersistenceProvider => _provider;

        public IWorkflowGenerator<XElement> AsWorkflowGenerator => _provider;
    }
}
