import React, { useState, useEffect } from "react";
import { Table } from "reactstrap";
import { getPlayerById } from "../../managers/playerManager";
import { useParams } from "react-router-dom";
const PlayerDetails = () => {
    const { id } = useParams();
    const [player, setPlayer] = useState(null);

    useEffect(() => {
        const fetchPlayerData = async () => {
            try {
                const response = await fetch(`/api/players/${id}`);
                if (!response.ok) {
                    throw new Error("Error fetching data");
                }

                const data = await response.json();
                setPlayer(data);
            } catch (error) {
                console.error("Error fetching data: " + error);
            }
        };

        if (id) {
            fetchPlayerData();
        }
    }, [id]);

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

export default PlayerDetails;