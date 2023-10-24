import React, { useState, useEffect } from "react";
import PlayerDetails from "./PlayerDetails";
import AddPlayerGame from "./AddPlayerGame";
import { useParams } from "react-router-dom";


const PlayerPage = () => {
    const [player, setPlayer] = useState(null);
    const { id } = useParams();
    const [refreshKey, setRefreshKey] = useState(0);
    
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

    if (!player) {
        return <div>Loading...</div>;
    }

    return (
        <div>
            <PlayerDetails player={player} />
            <AddPlayerGame playerId={player.id} />
        </div>
    );
};

export default PlayerPage;
