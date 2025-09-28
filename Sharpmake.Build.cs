// Copyright Tinfoil Engine. All Rights Reserved.

// Sharpmake build script

using Sharpmake;

using System;
using System.IO;

public class SharpmakeProject : TinfoilToolProjectBase
{
    public SharpmakeProject(string projectGuid)
    {
        m_ProjectGuid = projectGuid;
    }

    public override void ConfigureProject(Project.Configuration config, TinfoilTarget target)
    {
        config.Output = Configuration.OutputType.DotNetClassLibrary;
        config.ProjectGuid = m_ProjectGuid;

        config.ProjectPath = SourceRootPath;
        config.TargetPath = Path.Combine(SourceRootPath, "bin");
        config.IntermediatePath = Path.Combine(SourceRootPath, "obj");
    }

    private string m_ProjectGuid; // Original project GUID from the Sharpmake solution
}

[Sharpmake.Compile]
public class SharpmakeApplication : SharpmakeProject
{
    public SharpmakeApplication() : base(@"37CF3EE3-AFD3-3CC8-8F8E-B423292D491F")
    {
        Name = "Sharpmake.Application";
        SourceRootPath = @"[project.SharpmakeCsPath]/Sharpmake.Application";
    }

    public override void ConfigureProject(Project.Configuration config, TinfoilTarget target)
    {
        base.ConfigureProject(config, target);
        config.Output = Configuration.OutputType.DotNetConsoleApp;

        config.AddPrivateDependency<SharpmakeCommonPlatforms>(target, DependencySetting.Default);
        config.AddPrivateDependency<SharpmakeCore>(target, DependencySetting.Default);
        config.AddPrivateDependency<SharpmakeGenerators>(target, DependencySetting.Default);
    }
}

[Sharpmake.Compile]
public class SharpmakeCore : SharpmakeProject
{
    public SharpmakeCore() : base(@"15F793C7-9E88-64A9-591C-7244FCC6B771")
    {
        Name = "Sharpmake";
        SourceRootPath = @"[project.SharpmakeCsPath]/Sharpmake";
    }

    public override void ConfigureProject(Project.Configuration config, TinfoilTarget target)
    {
        base.ConfigureProject(config, target);
    }
}

[Sharpmake.Compile]
public class SharpmakeFunctionalTests : SharpmakeProject
{
    public SharpmakeFunctionalTests() : base(@"E659DEAC-D040-459F-9E6C-E694AF802DBC")
    {
        Name = "Sharpmake.FunctionalTests";
        SourceRootPath = @"[project.SharpmakeCsPath]/Sharpmake.FunctionalTests";
    }

    public override void ConfigureProject(Project.Configuration config, TinfoilTarget target)
    {
        base.ConfigureProject(config, target);

        config.AddPrivateDependency<SharpmakeApplication>(target, DependencySetting.Default);
    }
}

[Sharpmake.Compile]
public class SharpmakeGenerators : SharpmakeProject
{
    public SharpmakeGenerators() : base(@"844F66DE-B015-340E-720A-8E158B517E93")
    {
        Name = "Sharpmake.Generators";
        SourceRootPath = @"[project.SharpmakeCsPath]/Sharpmake.Generators";
    }

    public override void ConfigureProject(Project.Configuration config, TinfoilTarget target)
    {
        base.ConfigureProject(config, target);

        config.AddPrivateDependency<SharpmakeCore>(target, DependencySetting.Default);
    }
}

[Sharpmake.Compile]
public class SharpmakeCommonPlatforms : SharpmakeProject
{
    public SharpmakeCommonPlatforms() : base(@"6CA349ED-D54F-E547-E2AC-E11BEF4F21CF")
    {
        Name = "Sharpmake.CommonPlatforms";
        SourceRootPath = @"[project.SharpmakeCsPath]/Sharpmake.Platforms/Sharpmake.CommonPlatforms";
    }

    public override void ConfigureProject(Project.Configuration config, TinfoilTarget target)
    {
        base.ConfigureProject(config, target);

        config.AddPrivateDependency<SharpmakeCore>(target, DependencySetting.Default);
        config.AddPrivateDependency<SharpmakeGenerators>(target, DependencySetting.Default);
    }
}

[Sharpmake.Compile]
public class SharpmakeSamples : SharpmakeProject
{
    public SharpmakeSamples() : base(@"60452228-D411-4461-91D7-0894482D940C")
    {
        Name = "Samples";
        SourceRootPath = @"[project.SharpmakeCsPath]/Samples";
    }

    public override void ConfigureProject(Project.Configuration config, TinfoilTarget target)
    {
        base.ConfigureProject(config, target);

        config.AddPrivateDependency<SharpmakeApplication>(target, DependencySetting.Default);
    }
}

[Sharpmake.Compile]
public class SharpmakeUnitTests : SharpmakeProject
{
    public SharpmakeUnitTests() : base(@"3776B212-14C5-4038-9B97-2AACB2D10987")
    {
        Name = "Sharpmake.UnitTests";
        SourceRootPath = @"[project.SharpmakeCsPath]/Sharpmake.UnitTests";
    }

    public override void ConfigureProject(Project.Configuration config, TinfoilTarget target)
    {
        base.ConfigureProject(config, target);

        config.AddPrivateDependency<SharpmakeCommonPlatforms>(target, DependencySetting.Default);
        config.AddPrivateDependency<SharpmakeCore>(target, DependencySetting.Default);
        config.AddPrivateDependency<SharpmakeGenerators>(target, DependencySetting.Default);
    }
}

