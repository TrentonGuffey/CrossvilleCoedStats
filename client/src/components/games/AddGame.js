import React, { useEffect, useState } from "react";
import { Button, FormGroup, Label, Input, Form, FormText } from "reactstrap";
import Select from "react-select";
import {DatePicker} from 'reactstrap-date-picker'

const AddGame = ({ onAddGame, teams }) => {
    const [newGame, setNewGame] = useState({
        homeTeamId: "",
        visitorTeamId: "",
        gameTime: new Date().toISOString(),
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
        setNewGame({ ...newGame, gameTime: date.toISOString() });
    };

    const handleSelectChange = (selectedOption, name) => {
        let gameToModify = {...newGame}
        gameToModify[name] = selectedOption.value
        setNewGame(gameToModify);
    };

    return (
        <Form className="addGame">
            <FormGroup className="col-md-4">
                <Label className="label" for="homeTeamId">Home Team</Label>
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
            <FormGroup className="col-md-4">
                <Label className="label" for="visitorTeamId">Visitor Team</Label>
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
            <FormGroup className="col-md-4">
                <Label className="label" for="gameTime">Game Date & Time</Label>
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