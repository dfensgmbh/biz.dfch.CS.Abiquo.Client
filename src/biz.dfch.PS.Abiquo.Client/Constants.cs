﻿/**
 * Copyright 2016 d-fens GmbH
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biz.dfch.PS.Abiquo.Client
{
    /// <summary>
    /// Public constants used by this module
    /// </summary>
    public class Constants
    {
        /// <summary>
        /// Index for all cmdlets in this module
        /// </summary>
        public static class Cmdlets
        {
            /// <summary>
            /// Enter-Server
            /// </summary>
            public const int ENTER_SERVER = 1;

            /// <summary>
            /// Import-Configuratoin
            /// </summary>
            public const int IMPORT_CONFIGURATION = 2;
        }

        /// <summary>
        /// Names of all cmdlets in this module
        /// </summary>
        public static readonly string[] CmdletNames = new[]
        {
            typeof(EnterServer).ToString()
            ,
            typeof(ImportConfiguration).ToString()
            ,
        };
    }
}