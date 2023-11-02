import React, { useEffect, useState } from 'react';
import { getPositions } from '../../managers/posManager';
import { getTeams } from '../../managers/gameManager';
import { addPlayer } from '../../managers/playerManager';
import {
  Col,
  Form,
  FormGroup,
  Label,
  Input,
  Button,
} from 'reactstrap';

function Register() {
  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  const [positionId, setPositionId] = useState('');
  const [teamId, setTeamId] = useState('');
  const [positions, setPositions] = useState([]);
  const [teams, setTeams] = useState([]);

  useEffect(() => {
    getPositions()
      .then((positions) => {
        setPositions(positions);
      })
      .catch((error) => {
        console.error(error);
      });
  }, []); 

  useEffect(() => {
    getTeams()
      .then((teams) => {
        setTeams(teams);
      })
      .catch((error) => {
        console.error(error);
      });
  }, []); 


  const handleInputChange = (event) => {
    const { name, value } = event.target;
    if (name === 'firstName') setFirstName(value);
    else if (name === 'lastName') setLastName(value);
    else if (name === 'position') setPositionId(value);
    else if (name === 'team') setTeamId(value);
  };

  const handleSubmit = async (event) => {
    event.preventDefault();

    const playerData = {
      firstName,
      lastName,
      positionId,
      teamId,
    };
    await addPlayer(playerData)
    
      window.location.reload();
    
  };

  return (
    <div className="playerReg" style={{ maxWidth: "400px" }}>
      <h2 className="label">Player Registration</h2>
      <Form onSubmit={handleSubmit}>
        <FormGroup>
          <Label className="label" for="firstName">First Name:</Label>
          <Col>
            <Input className="custom-input"
              type="text"
              name="firstName"
              value={firstName}
              onChange={handleInputChange}
            />
          </Col>
        </FormGroup>
        <FormGroup row>
          <Label className="label" for="lastName">
            Last Name:
          </Label>
          <Col>
            <Input
              type="text"
              name="lastName"
              id="lastName"
              value={lastName}
              onChange={handleInputChange}
            />
          </Col>
        </FormGroup>
        <FormGroup row>
          <Label className="label" for="position">
            Position:
          </Label>
          <Col>
            <Input
              type="select"
              name="position"
              id="position"
              value={positionId}
              onChange={handleInputChange}
            >
              <option value="">Select Position</option>
              {positions.map((position) => (
                <option key={position.id} value={position.id}>
                  {position.pos}
                </option>
              ))}
            </Input>
          </Col>
        </FormGroup>
        <FormGroup>
          <Label className="label" for="team">
            Team:
          </Label>
          <Col>
            <Input
              type="select"
              name="team"
              id="team"
              value={teamId}
              onChange={handleInputChange}
            >
              <option value="">Select Team</option>
              {teams.map((team) => (
                <option key={team.id} value={team.id}>
                  {team.name}
                </option>
              ))}
            </Input>
          </Col>
        </FormGroup>
        <Button color="primary" type="submit">
          Submit
        </Button>
      </Form>
    </div>
  );
}


export default Register;
