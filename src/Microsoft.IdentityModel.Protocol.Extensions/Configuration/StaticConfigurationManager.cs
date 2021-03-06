﻿//-----------------------------------------------------------------------
// Copyright (c) Microsoft Open Technologies, Inc.
// All Rights Reserved
// Apache License 2.0
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//-----------------------------------------------------------------------

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.IdentityModel.Protocols
{
    /// <summary>
    /// StaticConfigurationManager
    /// </summary>
    /// <typeparam name="T">TODO</typeparam>
    public class StaticConfigurationManager<T> : IConfigurationManager<T>
    {
        private T _configuration;

        /// <summary>
        /// StaticConfigurationManager
        /// </summary>
        /// <param name="configuration">TODO</param>
        public StaticConfigurationManager(T configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException("configuration");
            }

            _configuration = configuration;
        }

        /// <summary>
        /// GetConfigurationAsync
        /// </summary>
        /// <param name="cancel">TODO</param>
        /// <returns>TODO</returns>
        public Task<T> GetConfigurationAsync(CancellationToken cancel)
        {
            return Task.FromResult(_configuration);
        }

        /// <summary>
        /// RequestRefresh
        /// </summary>
        /// <remarks>TODO</remarks>
        public void RequestRefresh()
        {
            // TODO: throw new NotSupportedException()?
        }
    }
}
