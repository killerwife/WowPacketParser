using WowPacketParser.Messages.Cli;

namespace WowPacketParser.Messages.Player
{
    public unsafe struct PlayerMoveSetIgnoreMovementForcesAck
    {
        public CliMovementAck Data;
    }
}