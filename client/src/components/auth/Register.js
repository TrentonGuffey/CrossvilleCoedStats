import React, { useEffect, useState } from 'react';
import { getPositions } from '../../managers/posManager';
import { getTeams } from '../../managers/gameManager';
import { addPlayer } from '../../managers/playerManager';
import styles from "./Register.css"

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
      <div className="register">
        <h2 className='addPlayerTitle'>Player Registration</h2>
        <form onSubmit={handleSubmit}>
          <div className='addPlayerFirstName'>
            <label>First Name:</label>
            <input
              type="text"
              name="firstName"
              value={firstName}
              onChange={handleInputChange}
            />
          </div>
          <div className='addPlayerLastName'>
            <label>Last Name:</label>
            <input
              type="text"
              name="lastName"
              value={lastName}
              onChange={handleInputChange}
            />
          </div>
          <div className='addPlayerPosition'>
          <label>Position:</label>
            <select 
              name="position"
              value={positionId}
              onChange={handleInputChange}
            >
              <option value="">Select Position</option>
              {positions.map((position) => (
                <option key={position.id} value={position.id}>
                  {position.pos}
                </option>
              ))} 
              </select>
          </div>
          <div className='addPlayerTeam'>
            <label>Team:</label>
            <select
              name="team"
              value={teamId}
              onChange={handleInputChange}
            >
              <option value="">Select Team</option>
              {teams.map((team) => (
                <option key={team.id} value={team.id}>
                  {team.name}
                </option>
              ))}
            </select>
          </div>
          <button className='addPlayerButton' type="submit">Submit</button>
        </form>
      </div>
    );
  }


export default Register;
