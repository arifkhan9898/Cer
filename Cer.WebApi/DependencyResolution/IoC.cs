// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IoC.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Cer.Core.Dtos;
using Cer.Core.Interfaces;
using Cer.Core.Interfaces.Services;
using Cer.Core.Models;
using Cer.Infrastructure.Contextes;
using Cer.Infrastructure.Data;
using Cer.Infrastructure.Interfaces;
using Cer.Service;
using StructureMap;
using StructureMap.Graph;
namespace Cer.WebApi.DependencyResolution
{
    public static class IoC
    {
        public static IContainer Initialize()
        {
            ObjectFactory.Initialize(x =>
            {
                x.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    scan.AssemblyContainingType<IRentalService>();   // Core
                    scan.AssemblyContainingType<RentalService>();    // Infrastructure
                    scan.AssemblyContainingType<CerDbContext>();    // Infrastructure
                });
                x.For(typeof(IRepository<>)).Use(typeof(Repository<>));
                x.For(typeof(IDbContext)).Use(typeof(CerDbContext));
                x.For(typeof(IRentalService)).Use(typeof(RentalService));
                x.For(typeof(IMapper<Equipment, EquipmentDto>)).Use(typeof(MapEquipmentDto));
            });

            return ObjectFactory.Container;
        }
    }
}