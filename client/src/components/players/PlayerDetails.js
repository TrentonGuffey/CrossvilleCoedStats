import React, { useState, useEffect } from "react";
import { Table } from "reactstrap";
import { getPlayerById } from "../../managers/playerManager";


export default function PlayerDetails({ detailsPlayerId }) {
    const [player, setPlayer] = useState(null);

    const getPlayerDetails = (id) => {
        getPlayerById(id).then(setPlayer);
    };

    useEffect(() => {
        if (detailsPlayerId) {
            getPlayerDetails(detailsPlayerId);
        }
    }, [detailsPlayerId]);

    if (!player) {
        return <div>Loading...</div>;
    }

    return (
        <div>
            <h2>{player.firstName} {player.lastName}</h2>
            <Table>
                <thead>
                    <tr>
                        <th>Game Date</th>
                        <th>Score</th>
                        {/* Add other table headers for PlayerGames properties */}
                    </tr>
                </thead>
                <tbody>
                    {player.playerGames.map(() => (
                        <tr key={player.playerGames.id}>
                            <td>{}</td>
                            <td>{}</td>
                            {/* Render other PlayerGames properties here */}
                        </tr>
                    ))}
                </tbody>
            </Table>
        </div>
    );
};

