import React, { useState, useEffect } from "react";
import { Button, Table } from "reactstrap";
import { format } from "date-fns";
import { deletePlayerGame } from "../../managers/playerGameManager";

const PlayerDetails = ({ player }) => {
    if (!player) {
        return <div>Loading...</div>;
    };

    const formatGameTime = (gameTime) => {
        const date = new Date(gameTime);
        return format(date, "MM-dd-yyyy HH:mm")
    };

    const handleDeleteGame = async (gameId) => {
        try {
            await deletePlayerGame(gameId);
            // You may want to refresh or update the player data here if needed.
            console.log("Player game deleted successfully");
            window.location.reload();
        } catch (error) {
            console.error("Error deleting player game: " + error);
        }
    };

    return (
        <div>
            <Table>
                <thead>
                    <tr>
                        <th>Game Date</th>
                        <th>Total Plate Appearances</th>
                        <th>Singles</th>
                        <th>Doubles</th>
                        <th>Triples</th>
                        <th>Home Runs</th>
                        <th>Walks</th>
                        <th>Sacrifices</th>
                        <th>Fielder's Choices</th>
                        <th>RBI's</th>
                        <th>Runs Scored</th>
                    </tr>
                </thead>
                <tbody>
                    {player.playerGames.map((game) => (
                        <tr key={game.id}>
                            <td>{formatGameTime(game.game.gameTime)}</td>
                            <td>{game.totalPlateAppearances}</td>
                            <td>{game.single}</td>
                            <td>{game.double}</td>
                            <td>{game.triple}</td>
                            <td>{game.homeRun}</td>
                            <td>{game.walk}</td>
                            <td>{game.sacrifice}</td>
                            <td>{game.fieldersChoice}</td>
                            <td>{game.runsBattedIn}</td>
                            <td>{game.runsScored}</td>
                            <td><Button color="danger" onClick={() => handleDeleteGame(game.id)}>Delete</Button></td>
                        </tr>
                    ))}
                </tbody>
            </Table>
        </div>
    );
};

export default PlayerDetails;