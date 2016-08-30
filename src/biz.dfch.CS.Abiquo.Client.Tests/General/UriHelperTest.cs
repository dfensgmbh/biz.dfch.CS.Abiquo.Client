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
﻿using biz.dfch.CS.Abiquo.Client.Communication;
﻿using biz.dfch.CS.Utilities.Testing;
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using biz.dfch.CS.Abiquo.Client.General;

namespace biz.dfch.CS.Abiquo.Client.Tests.General
{
    [TestClass]
    public class UriHelperTest
    {
        private const string ABIQUO_API_BASE_URI = "https://abiquo/api/";

        [TestMethod]
        [ExpectContractFailure]
        public void ConcatUriWithInvalidBaseUriThrowsContractException()
        {
            // Arrange

            // Act
            UriHelper.ConcatUri(null, AbiquoUriSuffixes.LOGIN);

            // Assert
        }

        [TestMethod]
        [ExpectContractFailure]
        public void ConcatUriWithEmptyBaseUriThrowsContractException()
        {
            // Arrange

            // Act
            UriHelper.ConcatUri(" ", AbiquoUriSuffixes.LOGIN);

            // Assert
        }

        [TestMethod]
        [ExpectContractFailure]
        public void ConcatUriWithNullUriSuffixThrowsContractException()
        {
            // Arrange

            // Act
            UriHelper.ConcatUri(ABIQUO_API_BASE_URI, null);

            // Assert
        }

        [TestMethod]
        [ExpectContractFailure]
        public void ConcatUriWithEmptyUriSuffixThrowsContractException()
        {
            // Arrange

            // Act
            UriHelper.ConcatUri(ABIQUO_API_BASE_URI, " ");
            
            // Assert
        }

        [TestMethod]
        public void ConcatUriReturnsValidUri()
        {
            // Arrange
            var expectedUri = "http://example.com/api/login";

            // Act

            // Assert
            Assert.AreEqual(expectedUri, UriHelper.ConcatUri("http://example.com/api/", "login"));
            Assert.AreEqual(expectedUri, UriHelper.ConcatUri("http://example.com/api/", "/login"));
            Assert.AreEqual(expectedUri, UriHelper.ConcatUri("http://example.com/api/", "login/"));
            Assert.AreEqual(expectedUri, UriHelper.ConcatUri("http://example.com/api/", "/login/"));
            Assert.AreEqual(expectedUri, UriHelper.ConcatUri("http://example.com/api", "login"));
            Assert.AreEqual(expectedUri, UriHelper.ConcatUri("http://example.com/api", "/login"));
            Assert.AreEqual(expectedUri, UriHelper.ConcatUri("http://example.com/api", "login/"));
            Assert.AreEqual(expectedUri, UriHelper.ConcatUri("http://example.com/api", "/login/"));
        }

        [TestMethod]
        [ExpectContractFailure]
        public void CreateFilterStringWithNullDictionaryThrowsContractException()
        {
            // Arrange

            // Act
            UriHelper.CreateFilterString(null);

            // Assert
        }

        [TestMethod]
        [ExpectContractFailure]
        public void CreateFilterStringWithEmptyDictionaryThrowsContractException()
        {
            // Arrange
            var emptyFilter = new Dictionary<string, object>();

            // Act
            UriHelper.CreateFilterString(emptyFilter);

            // Assert
        }

        [TestMethod]
        public void CreateFilterStringWithReturnsFilterAsString()
        {
            // Arrange
            var expectedFilterString = "maxSize=5&currentPage=1&limit=25";

            var filter = new Dictionary<string, object>()
            {
                {"maxSize", 5},
                {"currentPage", 1},
                {"limit", "25"}
            };

            // Act
            var filterString = UriHelper.CreateFilterString(filter);

            // Assert
            Assert.AreEqual(expectedFilterString, filterString);
        }

        [TestMethod]
        [ExpectContractFailure]
        public void ExtractIdFromHrefWithNullValueThrowsContractException()
        {
            // Arrange
            
            // Act
            UriHelper.ExtractIdFromHref(null);

            // Assert
        }

        [TestMethod]
        [ExpectContractFailure]
        public void ExtractIdFromHrefWithInvalidUriStringThrowsContractException()
        {
            // Arrange

            // Act
            UriHelper.ExtractIdFromHref("Arbitrary");

            // Assert
        }

        [TestMethod]
        [ExpectContractFailure]
        public void ExtractIdFromHrefWithUriNotContainigIdThrowsContractException()
        {
            // Arrange

            // Act
            UriHelper.ExtractIdFromHref(ABIQUO_API_BASE_URI);

            // Assert
        }

        [TestMethod]
        public void ExtractIdFromHrefWithUriContainigIdSucceeds()
        {
            // Arrange

            // Act
            var id = UriHelper.ExtractIdFromHref("https://example/api/users/155");

            // Assert
            Assert.IsTrue(155 == id);
        }
    }
}
