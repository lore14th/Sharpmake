﻿// Copyright (c) 2018-2019 Ubisoft Entertainment
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Sharpmake
{
    public partial class PackageReferences
    {
        /// <remarks>
        /// See : https://docs.microsoft.com/en-us/nuget/consume-packages/package-references-in-project-files#controlling-dependency-assets
        /// </remarks>
        private const string TemplateBeginPackageReference = "    <PackageReference Include=\"[packageName]\" Version=\"[packageVersion]\"";
        private const string TemplatePackagePrivateAssets = "        <PrivateAssets>[privateAssets]</PrivateAssets>\n";
        private const string TemplateEndPackageReference = "    </PackageReference>\n";
    }
}
