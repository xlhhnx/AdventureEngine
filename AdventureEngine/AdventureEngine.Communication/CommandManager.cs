using System.Collections.Generic;

public class CommandManager
{
    protected Queue<ICommand> _commands;

    /// <summary>
    /// Creates a CommandManager.
    /// </summary>
    public CommandManager()
    {
        _commands = new Queue<ICommand>();
    }

    /// <summary>
    /// Enqueues a command.
    /// </summary>
    /// <param name="command">The command to be enqueued.</param>
    public void Enqueue(ICommand command)
    {
        _commands.Enqueue(command);
    }

    /// <summary>
    /// Executes all commands in the queue.
    /// </summary>
    public void Update()
    {
        var executingCommands = new Queue<ICommand>(_commands);
        _commands = new Queue<ICommand>();

        foreach (ICommand cmd in executingCommands)
        {
            cmd.Execute();
        }
    }
}