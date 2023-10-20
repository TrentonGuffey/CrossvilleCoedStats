import React, { useState, useEffect } from "react";
import { Button, Table } from "reactstrap";

const GameTable = () => {
    const [games, setGames] = useState([]);

    useEffect(() => {
        fetch("api/games")
        .then((response) => response.json())
        .then((data) => setGames(data))
        .catch((error) => console.error("Error fetching data: " + error));
    }, []);

    const handleDelete = (gameId) => {
        fetch(`/api/games/${gameId}`, {
            method: 'DELETE',
        })
            .then((response) => {
                if (response.ok) {
                    console.log("Game was deleted successfully");
                    fetch("api/games")
                        .then((response) => response.json())
                        .then((data) => setGames(data))
                        .catch((error) => console.error("Error fetching data: " + error));
                } else {
                    console.error("Error deleting game.");

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
                    <th>Game Time & Date</th>
                    <th>Visting Team</th>
                    <th>Home Team</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                {games.map((game) => (
                    <tr key={game.id}>
                        <td>{game.gameTime}</td>
                        <td>{game.visitorTeam.name}</td>
                        <td>{game.homeTeam.name}</td>
                        <td>
                            <Button color="danger" onClick={() => handleDelete(game.id)}>
                                Delete
                            </Button>
                        </td>
                    </tr>
                ))}
            </tbody>
        </Table>
    );
};

export default GameTable;