import React, { useState, useEffect } from "react";
import PlayerDetails from "./PlayerDetails";
import AddPlayerGame from "./AddPlayerGame";
import { useParams } from "react-router-dom";
import EditTeam from "./EditTeam";
import { deletePlayerGame } from "../../managers/playerGameManager";
import { getPlayerById } from "../../managers/playerManager";


const PlayerPage = ({loggedInUser}) => {
    const [player, setPlayer] = useState(null);
    const { id } = useParams();
    
    useEffect(() => {
        const fetchPlayerData = async () => {
            try {
                const response = await fetch(`/api/players/${id}`);
                if (!response.ok) {
                    throw new Error("Error fetching data");
                }
                
                const data = await response.json();
                setPlayer(data);
            } catch (error) {
                console.error("Error fetching data: " + error);
            }
        };
        
        if (id) {
            fetchPlayerData();
        }
    }, [id]);

    const handleDeleteGame = async (gameId) => {
        try {
            await deletePlayerGame(gameId);
            // refresh the player data
            const updatedPlayerData = await getPlayerById(id);
            setPlayer(updatedPlayerData);
            console.log("Player game deleted successfully");
        } catch (error) {
            console.error("Error deleting player game: " + error)
        }
    };


    if (!player) {
        return <div>Loading...playerpage</div>;
    }
    return (
        <div>
            <h2>
                {player.firstName} {player.lastName}, {player.pos.pos} , {player.team.name}
            </h2>
            <PlayerDetails player={player} loggedInUser={loggedInUser} handleDeleteGame={handleDeleteGame}/>
            <AddPlayerGame playerId={player.id} />
            {loggedInUser.roles.includes("Admin") && <EditTeam player={player} />}
            {/* <EditTeam player={player} /> */}
        </div>
    );
};

export default PlayerPage;
