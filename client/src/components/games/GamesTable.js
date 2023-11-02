import React, { useState, useEffect } from "react";
import { Button, Table } from "reactstrap";
import { format } from "date-fns";
import AddGame from "./AddGame";
import { getGames, getTeams } from "../../managers/gameManager";

const GameTable = ({loggedInUser}) => {
    const [games, setGames] = useState([]);
    const [teams, setTeams] = useState([]);

    useEffect(() => {
        getTeams()
            .then((data) => setTeams(data))
            .catch((error) => console.error("Error fetching teams: " + error));
    }, []);

    useEffect(() => {
        getGames()
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

    const formatGameTime = (gameTime) => {
        const date = new Date(gameTime);
        return format(date, "MM-dd-yyyy HH:mm")
    };

    const handleAddGame = (newGame) => {
        console.log("newGame:", newGame);
        console.log("teams:", teams);

        fetch("api/games", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(newGame),
        })
            .then((response) => {
                if (response.ok) {
                    console.log("Game added successfully");
                    fetch("api/games")
                        .then((response) => response.json())
                        .then((data) => setGames(data))
                        .catch((error) => console.error("Error fetching data: " + error));
                } else {
                    console.error("Error adding game.");
                }
            })
            .catch((error) => {
                console.error("Network error: " + error);
            });
    };

    return (
        <div>
        <Table className="gameTable">
            <thead>
                <tr>
                    <th style={{width: '30%'}}>Game Time & Date</th>
                    <th style={{width: '30%'}}>Visting Team</th>
                    <th style={{width: '30%'}}>Home Team</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                {games.map((game) => (
                    <tr key={game.id}>
                        <td>{formatGameTime(game.gameTime)}</td>
                        <td>{game.visitorTeam.name}</td>
                        <td>{game.homeTeam.name}</td>
                        <td>
                        {loggedInUser.roles.includes("Admin") ? (
                                <Button color="danger" onClick={() => handleDelete(game.id)}>
                                    Delete
                                </Button>
                            ) : null}
                        </td>
                    </tr>
                ))}
            </tbody>
        </Table>
        {loggedInUser.roles.includes("Admin") && <AddGame onAddGame={handleAddGame} teams={teams} />}
        </div>
    );
};

export default GameTable;