import React, { useState, useEffect } from "react";
import { Button, Table } from "reactstrap";
import { Link } from "react-router-dom";

const PlayerTable = () => {
    const [players, setPlayers] = useState([]);

    useEffect(() => {
        fetch("/api/players")
            .then((response) => response.json())
            .then((data) => setPlayers(data))
            .catch((error) => console.error("Error fetching data: " + error));
    }, []);

    const handleDelete = (playerId) => {
        fetch(`/api/players/${playerId}`, {
            method: 'DELETE',
        })
        .then((response) => {
            if (response.ok) {
                console.log(`Player was deleted successfully.`);
                fetch("/api/players")
                    .then((response) => response.json())
                    .then((data) => setPlayers(data))
                    .catch((error) => console.error("Error fetching data: " + error));
            } else {
                console.error(`Error deleting player.`);
            }
        })
        .catch((error) => {
            console.error("Network error: " + error);
        })
    };

    return (
        <Table>
            <thead>
                <tr>
                    <th></th>
                    <th>Team Name</th>
                    <th>Name</th>
                    <th>ID</th>
                    <th>Official AB's</th>
                    <th>Total Hits</th>
                    <th>Batting Avg</th>
                    <th>Runs Scored</th>
                    <th>RBI's</th>
                    {/* Add other table headers for player properties */}
                </tr>
            </thead>
            <tbody>
                {players.map((player) => (
                    <tr key={player.id}>
                        <td>
                            <Button color="danger" onClick={() => handleDelete(player.id)}>
                                Delete
                            </Button>
                        </td>
                        <td>{player.team.name}</td>
                        <td><Link to={`/players/${player.id}`}>
                            {player.firstName} {player.lastName}
                        </Link></td>
                        <td>{player.id}</td>
                        <td>{player.officialAtBats}</td>
                        <td>{player.totalHits}</td>
                        <td>{player.battingAverage}</td>
                        <td>{player.totalRunsScored}</td>
                        <td>{player.totalRBIs}</td>
                        {/* Render other player properties here */}
                    </tr>
                ))}
            </tbody>
        </Table>
    );
};

export default PlayerTable;
