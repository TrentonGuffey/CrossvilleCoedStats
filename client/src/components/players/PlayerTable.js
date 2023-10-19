import React, { useState, useEffect } from "react";
import { Table } from "reactstrap";
import { Link } from "react-router-dom";

const PlayerTable = () => {
    const [players, setPlayers] = useState([]);

    useEffect(() => {
        // Fetch player data from the API
        fetch("/api/players")
            .then((response) => response.json())
            .then((data) => setPlayers(data))
            .catch((error) => console.error("Error fetching data: " + error));
    }, []);

    return (
        <Table>
            <thead>
                <tr>
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
