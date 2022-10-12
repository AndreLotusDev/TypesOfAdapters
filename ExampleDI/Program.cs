using Autofac;
using Autofac.Features.Metadata;
using AutofacDemos;

var b = new ContainerBuilder();
b.RegisterType<OpenCommand>()
    .As<ICommand>()
    .WithMetadata("Name", "Open");
b.RegisterType<SaveCommand>()
    .As<ICommand>()
    .WithMetadata("Name", "Save");
//b.RegisterType<Button>();
// b.RegisterAdapter<ICommand, Button>(cmd => new Button(cmd, ""));
b.RegisterAdapter<Meta<ICommand>, Button>(cmd =>
    new Button(cmd.Value, (string)cmd.Metadata["Name"]));
b.RegisterType<Editor>();
using (var c = b.Build())
{
    var editor = c.Resolve<Editor>();
    editor.ClickAll();

    // problem: only one button

    foreach (var btn in editor.Buttons)
        btn.PrintMe();


}