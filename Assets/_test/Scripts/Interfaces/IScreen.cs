public interface IScreen {

    void EnterScreen();
    bool FinishedTransition { get; }

    void LeaveScreen();
    bool LeftScreen { get; }
}