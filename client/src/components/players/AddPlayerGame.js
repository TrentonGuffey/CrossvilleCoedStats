import React, { useState, useEffect, useRef } from "react";
import { Form, FormGroup, Label, Input, Button } from "reactstrap";
import { useParams } from "react-router-dom";

const AddPlayerGame = () => {
    const { id } = useParams();
    const [gameList, setGameList] = useState([]);
    const [selectedGame, setSelectedGame] = useState(null);

    const formRef = useRef(null);

    useEffect(() => {
        const fetchGameList = async () => {
            try {
                const response = await fetch("/api/games");
                if (!response.ok) {
                    throw new Error("Error fetching game list");
                }
                const data = await response.json();
                setGameList(data);
            } catch (error) {
                console.error("Error fetching game list: " + error);
            }
        };

        fetchGameList();
    }, []);

    const handleGameSelect = (event) => {
        setSelectedGame(event.target.value);
    };

    const handleFormSubmit = async (event) => {
        event.preventDefault();

        const playerGameData = {
            playerId: id,
            gameId: selectedGame,
            totalPlateAppearances: event.target.totalPlateAppearances.value,
            single: event.target.single.value,
            double: event.target.double.value,
            triple: event.target.triple.value,
            homeRun: event.target.homeRun.value,
            walk: event.target.walk.value,
            sacrifice: event.target.sacrifice.value,
            fieldersChoice: event.target.fieldersChoice.value,
            runsBattedIn: event.target.runsBattedIn.value,
            runsScored: event.target.runsScored.value
            // Continue to add the Properties of a player Game
        };

        try {
            const response = await fetch("/api/playergames", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(playerGameData),
            });

            if (!response.ok) {
                throw new Error("Error adding player game stats");
            }

            // Handle success, e.g., reset the form or show a success message
            console.log("Player game stats added successfully");
            formRef.current.reset();
            window.location.reload();
        } catch (error) {
            console.error("Error adding player game stats: " + error);
            console.log(playerGameData);
        }
    };

    return (

        <div className="container">
            <h2 className="label">Add Game Stats</h2>
            <div className="row">
                <div className="col-md-6">
                    <Form innerRef={formRef} onSubmit={handleFormSubmit}>
                        <FormGroup>
                            <Label className="label" for="totalPlateAppearances">Total Plate Appearances</Label>
                            <Input type="number" name="totalPlateAppearances" id="totalPlateAppearances" />
                        </FormGroup>
                        <FormGroup>
                            <Label className="label" for="single">Singles</Label>
                            <Input type="number" name="single" id="single" />
                        </FormGroup>
                        <FormGroup>
                            <Label className="label" for="double">Doubles</Label>
                            <Input type="number" name="double" id="double" />
                        </FormGroup>
                        <FormGroup>
                            <Label className="label" for="triple">Triples</Label>
                            <Input type="number" name="triple" id="triple" />
                        </FormGroup>
                        <FormGroup>
                            <Label className="label" for="homeRun">Home Runs</Label>
                            <Input type="number" name="homeRun" id="homeRun" />
                        </FormGroup>
                        <FormGroup>
                            <Label className="label" for="walk">Walks</Label>
                            <Input type="number" name="walk" id="walk" />
                        </FormGroup>
                        <FormGroup>
                            <Label className="label" for="sacrifice">Sacrifices</Label>
                            <Input type="number" name="sacrifice" id="sacrifice" />
                        </FormGroup>
                        <FormGroup>
                            <Label className="label" for="fieldersChoice">Fielders Choices</Label>
                            <Input type="number" name="fieldersChoice" id="fieldersChoice" />
                        </FormGroup>
                        <FormGroup>
                            <Label className="label" for="runsBattedIn">RBI's</Label>
                            <Input type="number" name="runsBattedIn" id="runsBattedIn" />
                        </FormGroup>
                        <FormGroup>
                            <Label className="label" for="runsScored">Runs Scored</Label>
                            <Input type="number" name="runsScored" id="runsScored" />
                        </FormGroup>
                        {/* Add other form fields similarly */}
                        <Button type="submit">Submit</Button>
                    </Form>
                </div>
                <div className="col-md-6">
                    <FormGroup>
                        <Label className="label" for="game">Select Game</Label>
                        <Input type="select" name="game" id="game" onChange={handleGameSelect}>
                            <option value="">Select a Game</option>
                            {gameList.map((game) => (
                                <option key={game.id} value={game.id}>
                                    {game.gameTime}
                                </option>
                            ))}
                        </Input>
                    </FormGroup>
                </div>
            </div>
        </div>
    );
};

export default AddPlayerGame;