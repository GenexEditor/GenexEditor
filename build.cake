// ARGUMENTS

var _target = Argument("target", "Default");

// TASKS

Task("BuildWindows")
    .WithCriteria(() => IsRunningOnWindows())
    .Does(() =>
{
    NuGetRestore(
        "Source/GenexEditor/GenexEditor.Windows/GenexEditor.Windows.csproj",
        new NuGetRestoreSettings
        {
            PackagesDirectory = "Source/packages"
        }
    );

    MSBuild(
        "Source/GenexEditor/GenexEditor.Windows/GenexEditor.Windows.csproj",
        configurator => configurator
            .SetConfiguration("Release")
            .SetVerbosity(Verbosity.Minimal)
    );
});

Task("BuildLinux")
    .WithCriteria(() => IsRunningOnUnix())
    .Does(() =>
{
    NuGetRestore(
        "Source/GenexEditor/GenexEditor.Linux/GenexEditor.Linux.csproj",
        new NuGetRestoreSettings
        {
            PackagesDirectory = "Source/packages"
        }
    );

    XBuild(
        "Source/GenexEditor/GenexEditor.Linux/GenexEditor.Linux.csproj",
        configurator => configurator
            .SetConfiguration("Release")
            .SetVerbosity(Verbosity.Minimal)
    );
});

// TASK TARGETS

Task("Default")
    .IsDependentOn("Build");

Task("Build")
    .IsDependentOn("BuildWindows")
    .IsDependentOn("BuildLinux");

// EXECUTION

RunTarget(_target);
