
public abstract class Screen : IScreen {
    public abstract bool FinishedTransition { get; set; }

    public abstract bool LeftScreen { get; set; }

    public abstract void EnterScreen();

    public abstract void LeaveScreen();

}
