// Copyright TinfoilBuildTool. All Rights Reserved.

// Sharpmake build script

using System.IO;

using Sharpmake;
using TinfoilBuildTool;

public class SharpmakeBaseProject : DotNetProject
{
    public SharpmakeBaseProject(string projectGuid)
    {
        m_ProjectGuid = projectGuid;
    }

    public override void Configure(Configuration config, ITarget target)
    {
        base.Configure(config, target);
        config.Output = Configuration.OutputType.DotNetClassLibrary; // override output type

        // Since this project is used by multiple ProjectConfigurations, we can't really rely on the ProjectConfiguration 
        // to setup the output directories. We need to override them manually
        config.ProjectPath = SourceRootPath;
        config.TargetPath = Path.Combine(SourceRootPath, "bin");
        config.IntermediatePath = Path.Combine(SourceRootPath, "obj");
        config.BaseIntermediateOutputPath = config.IntermediatePath;

        config.ProjectGuid = m_ProjectGuid;
    }

    private string m_ProjectGuid; // Original project GUID from the Sharpmake solution
}

[Sharpmake.Compile]
public class SharpmakeApplicationProject : SharpmakeBaseProject
{
    public SharpmakeApplicationProject() : base(@"37CF3EE3-AFD3-3CC8-8F8E-B423292D491F")
    {
        Name = "Sharpmake.Application";
        SourceRootPath = @"[project.SharpmakeCsPath]/Sharpmake.Application";
    }

    public override void Configure(Configuration config, ITarget target)
    {
        base.Configure(config, target);
        config.Output = Configuration.OutputType.DotNetConsoleApp; // override output type

        config.AddPrivateDependency<SharpmakeCommonPlatformsProject>(target, DependencySetting.Default);
        config.AddPrivateDependency<SharpmakeCoreProject>(target, DependencySetting.Default);
        config.AddPrivateDependency<SharpmakeGeneratorsProject>(target, DependencySetting.Default);
    }
}

[Sharpmake.Compile]
public class SharpmakeCoreProject : SharpmakeBaseProject
{
    public SharpmakeCoreProject() : base(@"15F793C7-9E88-64A9-591C-7244FCC6B771")
    {
        Name = "Sharpmake";
        SourceRootPath = @"[project.SharpmakeCsPath]/Sharpmake";
    }

    public override void Configure(Configuration config, ITarget target)
    {
        base.Configure(config, target);
    }
}

[Sharpmake.Compile]
public class SharpmakeFunctionalTestsProject : SharpmakeBaseProject
{
    public SharpmakeFunctionalTestsProject() : base(@"E659DEAC-D040-459F-9E6C-E694AF802DBC")
    {
        Name = "Sharpmake.FunctionalTests";
        SourceRootPath = @"[project.SharpmakeCsPath]/Sharpmake.FunctionalTests";
    }

    public override void Configure(Configuration config, ITarget target)
    {
        base.Configure(config, target);

        config.AddPrivateDependency<SharpmakeApplicationProject>(target, DependencySetting.Default);
    }
}

[Sharpmake.Compile]
public class SharpmakeGeneratorsProject : SharpmakeBaseProject
{
    public SharpmakeGeneratorsProject() : base(@"844F66DE-B015-340E-720A-8E158B517E93")
    {
        Name = "Sharpmake.Generators";
        SourceRootPath = @"[project.SharpmakeCsPath]/Sharpmake.Generators";
    }

    public override void Configure(Configuration config, ITarget target)
    {
        base.Configure(config, target);

        config.AddPrivateDependency<SharpmakeCoreProject>(target, DependencySetting.Default);
    }
}

[Sharpmake.Compile]
public class SharpmakeCommonPlatformsProject : SharpmakeBaseProject
{
    public SharpmakeCommonPlatformsProject() : base(@"6CA349ED-D54F-E547-E2AC-E11BEF4F21CF")
    {
        Name = "Sharpmake.CommonPlatforms";
        SourceRootPath = @"[project.SharpmakeCsPath]/Sharpmake.Platforms/Sharpmake.CommonPlatforms";
    }

    public override void Configure(Configuration config, ITarget target)
    {
        base.Configure(config, target);

        config.AddPrivateDependency<SharpmakeCoreProject>(target, DependencySetting.Default);
        config.AddPrivateDependency<SharpmakeGeneratorsProject>(target, DependencySetting.Default);
    }
}

[Sharpmake.Compile]
public class SharpmakeSamplesProject : SharpmakeBaseProject
{
    public SharpmakeSamplesProject() : base(@"60452228-D411-4461-91D7-0894482D940C")
    {
        Name = "Samples";
        SourceRootPath = @"[project.SharpmakeCsPath]/Samples";
    }

    public override void Configure(Configuration config, ITarget target)
    {
        base.Configure(config, target);

        config.AddPrivateDependency<SharpmakeApplicationProject>(target, DependencySetting.Default);
    }
}

[Sharpmake.Compile]
public class SharpmakeUnitTestsProject : SharpmakeBaseProject
{
    public SharpmakeUnitTestsProject() : base(@"3776B212-14C5-4038-9B97-2AACB2D10987")
    {
        Name = "Sharpmake.UnitTests";
        SourceRootPath = @"[project.SharpmakeCsPath]/Sharpmake.UnitTests";
    }

    public override void Configure(Configuration config, ITarget target)
    {
        base.Configure(config, target);

        config.AddPrivateDependency<SharpmakeCommonPlatformsProject>(target, DependencySetting.Default);
        config.AddPrivateDependency<SharpmakeCoreProject>(target, DependencySetting.Default);
        config.AddPrivateDependency<SharpmakeGeneratorsProject>(target, DependencySetting.Default);
    }
}
