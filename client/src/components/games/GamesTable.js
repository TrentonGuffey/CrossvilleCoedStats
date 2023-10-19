import React, { useState, useEffect } from "react";
import { Table } from "reactstrap";

const GameTable = () => {
    const [games, setGames] = useState([]);

    useEffect(() => {
        fetch("api/games")
        .then((response) => response.json())
        .then((data) => setGames(data))
        .catch((error) => console.error("Error fetching data: " + error));
    }, []);

    return (
        <Table>
            <thead>
                <tr>
                    <th>Game Time & Date</th>
                    <th>Visting Team</th>
                    <th>Home Team</th>
                </tr>
            </thead>
            <tbody>
                {games.map((game) => (
                    <tr key={game.id}>
                        <td>{game.gameTime}</td>
                        <td>{game.visitorTeam.name}</td>
                        <td>{game.homeTeam.name}</td>
                    </tr>
                ))}
            </tbody>
        </Table>
    );
};

export default GameTable;