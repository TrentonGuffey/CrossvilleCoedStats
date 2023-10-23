import React, { useEffect, useState } from "react";
import { Button, FormGroup, Label, Input, Form } from "reactstrap";
import DatePicker from "react-datepicker";
import Select from "react-select";

const AddGame = ({ onAddGame, teams }) => {
    const [newGame, setNewGame] = useState({
        homeTeamId: "",
        visitorTeamId: "",
        gameTime: new Date(),
    });

    useEffect(() => {
        let game = newGame
        console.log(game)
    }, [newGame]);

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setNewGame({ ...newGame, [name]: value });
    };

    const handleDateChange = (date) => {
        setNewGame({ ...newGame, gameTime: date });
    };

    const handleSelectChange = (selectedOption, name) => {
        let gameToModify = {...newGame}
        gameToModify[name] = selectedOption.value
        setNewGame(gameToModify);
    };

    return (
        <Form>
            <FormGroup>
                <Label for="homeTeamId">Home Team</Label>
                <Select
                    id="homeTeamId"
                    name="homeTeamId"
                    options={teams.map((team) => ({
                        value: team.id,
                        label: team.name,
                    }))}
                    onChange={(selectedOption) => handleSelectChange(selectedOption, "homeTeamId")}
                />
            </FormGroup>
            <FormGroup>
                <Label for="visitorTeamId">Visitor Team</Label>
                <Select
                    id="visitorTeamId"
                    name="visitorTeamId"
                    options={teams.map((team) => ({
                        value: team.id,
                        label: team.name,
                    }))}
                    onChange={(selectedOption) => handleSelectChange(selectedOption, "visitorTeamId")}
                />
            </FormGroup>
            <FormGroup>
                <Label for="gameTime">Game Date & Time</Label>
                <DatePicker
                    id="gameTime"
                    name="gameTime"
                    selected={newGame.gameTime}
                    onChange={handleDateChange}
                    showTimeSelect
                    timeFormat="HH:mm"
                    timeIntervals={15}
                    dateFormat="MM-dd-yyyy HH:mm"
                />
            </FormGroup>
            <Button color="primary" onClick={() => onAddGame(newGame)}>
                Add Game
            </Button>
        </Form>
    );
};

export default AddGame;