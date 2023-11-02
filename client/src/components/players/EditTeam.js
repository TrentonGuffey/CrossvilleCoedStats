import React, { useState, useEffect } from "react";
import { useHistory, useNavigate, useParams } from "react-router-dom";
import { getTeams } from "../../managers/teamManager";
import { Button, } from "reactstrap";

const EditTeam = ( {player} ) => {
    const [selectedTeam, setSelectedTeam] = useState(); // State to store the selected team
    const [availableTeams, setAvailableTeams] = useState([]);
    const { id } = useParams();    
    const navigate = useNavigate();

    useEffect(() => {

        const fetchTeams = async () => {
            try {
                const teams = await getTeams();
                setAvailableTeams(teams);
            } catch (error) {
                console.error("Error fetching teams: " + error);
            }
        };

        if (id) {
            // fetchPlayerData();
            fetchTeams();
        }
    }, [id]);

    const handleTeamChange = (event) => {
        setSelectedTeam(parseInt(event.target.value));
    };

    const handleSubmit = async () => {
        try {

            player.teamId = selectedTeam;
            
            let modifiedPlayer = {
                id: player.id,
                firstName: player.firstName,
                lastName: player.lastName,
                positionId: player.positionId,
                teamId: player.teamId
            }

            const request = {
                method: "PUT",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(modifiedPlayer),
            };
            console.log(typeof id)
            const response = await fetch(`/api/players/${id}/editTeam`, request);

            if (response.ok) {
                navigate(`/players`);
            } else {
                console.error("Error updating player's team response ");
            }
        } catch (error) {
            console.error("Error updating player's team: " + error);
        }
    };
    if (!player) {
        return <div>Loading...</div>;
    }

    return (
        <div className="editTeam">
            <h2 className="label" >Edit Player's Team</h2>
            <h3 className="label" >{player.firstName} {player.lastName}</h3>
            <label className="label" >Select New Team:</label>
            <select value={selectedTeam} onChange={handleTeamChange}>
                {availableTeams.map((team) => (
                    team.id === player.teamId ? 
                    <option key={team.id} value={team.id} selected>
                        {team.name}
                    </option>:
                    <option key={team.id} value={team.id}>
                        {team.name}
                    </option>
                ))}
            </select>
            <Button onClick={handleSubmit}>Save Team</Button>
        </div>
    );
};

export default EditTeam;
