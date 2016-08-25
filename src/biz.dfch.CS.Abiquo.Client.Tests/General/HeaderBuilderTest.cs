/**
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
 
﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
﻿using biz.dfch.CS.Abiquo.Client.Authentication;
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using biz.dfch.CS.Abiquo.Client.General;
using biz.dfch.CS.Abiquo.Client.v1;
﻿using biz.dfch.CS.Utilities.Testing;

namespace biz.dfch.CS.Abiquo.Client.Tests.General
{
    [TestClass]
    public class HeaderBuilderTest
    {
        [ExpectContractFailure]
        [TestMethod]
        public void BuildAcceptHeaderWithNullValueThrowsContractException()
        {
            // Arrange

            // Act
            new HeaderBuilder().BuildAccept(null);

            // Assert
        }

        [ExpectContractFailure]
        [TestMethod]
        public void BuildAcceptHeaderWithEmptyValueThrowsContractException()
        {
            // Arrange

            // Act
            new HeaderBuilder().BuildAccept(" ");

            // Assert
        }

        [TestMethod]
        public void BuildAcceptHeaderReturnsDictionaryContainingExpectedAcceptHeader()
        {
            // Arrange

            // Act
            var headers = new HeaderBuilder().BuildAccept(AbiquoMediaDataTypes.VND_ABIQUO_ENTERPRISE).GetHeaders();

            // Assert
            Assert.AreEqual(1, headers.Count);
            Assert.IsTrue(headers.ContainsKey(Constants.ACCEPT_HEADER_KEY));
            Assert.AreEqual(AbiquoMediaDataTypes.VND_ABIQUO_ENTERPRISE, headers[Constants.ACCEPT_HEADER_KEY]);
        }

        [ExpectContractFailure]
        [TestMethod]
        public void BuildContentTypeHeaderWithNullValueThrowsContractException()
        {
            // Arrange

            // Act
            new HeaderBuilder().BuildContentType(null);

            // Assert
        }

        [ExpectContractFailure]
        [TestMethod]
        public void BuildContentTypeHeaderWithEmptyValueThrowsContractException()
        {
            // Arrange

            // Act
            new HeaderBuilder().BuildContentType(" ");

            // Assert
        }

        [TestMethod]
        public void BuildContentTypeHeaderReturnsDictionaryContainingExpectedAcceptHeader()
        {
            // Arrange

            // Act
            var headers = new HeaderBuilder().BuildContentType(AbiquoMediaDataTypes.VND_ABIQUO_ENTERPRISE).GetHeaders();

            // Assert
            Assert.AreEqual(1, headers.Count);
            Assert.IsTrue(headers.ContainsKey(Constants.CONTENT_TYPE_HEADER_KEY));
            Assert.AreEqual(AbiquoMediaDataTypes.VND_ABIQUO_ENTERPRISE, headers[Constants.CONTENT_TYPE_HEADER_KEY]);
        }
    }
}
