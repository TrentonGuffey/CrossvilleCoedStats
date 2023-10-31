import React, { useState, useEffect } from "react";
import { Button, Table } from "reactstrap";
import { Link } from "react-router-dom";
import { FaSort, FaSortUp, FaSortDown } from "react-icons/fa";
import { deletePlayer, getPlayers } from "../../managers/playerManager";


const PlayerTable = ({loggedInUser}) => {
    const [players, setPlayers] = useState([]);
    const [sortColumn, setSortColumn] = useState("firstName");
    const [sortOrder, setSortOrder] = useState("asc");

    useEffect(() => {
        getPlayers().then((data) => setPlayers(data))
            .catch((error) => console.error("Error fetching data: " + error));
    }, []);

    const handleDelete = (playerId) =>{
        deletePlayer(playerId).then(() => {
            console.log(`Player was deleted successfully.`);
            getPlayers().then((data) => setPlayers(data));
        })
        .catch((error) => {
            console.error(`Error deleting player: ${error}`);
        });
    }; 

    const handleSort = (column) => {
        if (column === sortColumn) {
            setSortOrder(sortOrder === "asc" ? "desc" : "asc");
        } else {
            setSortColumn(column);
            setSortOrder("asc");
        }
    };

    const getSortingSymbol = (column) => {
        if (column === sortColumn) {
            return sortOrder === "asc" ? <FaSortUp /> : <FaSortDown />;
        }
        return <FaSort />;
    };
    console.log(loggedInUser);
    return (
        <Table>
            <thead>
                <tr>
                    <th></th>
                    <th onClick={() => handleSort("team.name")}>Team Name {getSortingSymbol("team.name")}</th>
                    <th onClick={() => handleSort("firstName")}>Name {getSortingSymbol("firstName")}</th>
                    <th onClick={() => handleSort("officialAtBats")}>Official AB's {getSortingSymbol("officalAtBats")}</th>
                    <th onClick={() => handleSort("totalHits")}>Total Hits {getSortingSymbol("totalHits")}</th>
                    <th onClick={() => handleSort("battingAverage")}>Batting Avg {getSortingSymbol("battingAverage")}</th>
                    <th onClick={() => handleSort("totalRunsScored")}>Runs Scored {getSortingSymbol("totalRunsScored")}</th>
                    <th onClick={() => handleSort("totalRBIs")}>RBI's {getSortingSymbol("totalRBIs")}</th>
                    {/* Add other table headers for player properties */}
                </tr>
            </thead>
            <tbody>
                {players.slice().sort((a, b) => {
                    const valueA = a[sortColumn];
                    const valueB = b[sortColumn];

                    if (sortOrder === "asc") {
                        return valueA < valueB ? -1 : 1;
                    } else {
                        return valueA > valueB ? -1 : 1;
                    }
                })
                .map((player) => (
                    <tr key={player.id}>
                        <td>
                            {loggedInUser.roles.includes("Admin") ? (
                                <Button color="danger" onClick={() => handleDelete(player.id)}>
                                    Delete
                                </Button>
                            ) : null}
                        </td>
                        <td>{player.team.name}</td>
                        <td><Link to={`/players/${player.id}`}>
                            {player.firstName} {player.lastName}
                        </Link></td>
                        <td>{player.officialAtBats}</td>
                        <td>{player.totalHits}</td>
                        <td>{player.battingAverage}</td>
                        <td>{player.totalRunsScored}</td>
                        <td>{player.totalRBIs}</td>
                        {/* Render other player properties here */}
                    </tr>
                ))}
            </tbody>
        </Table>
    );
};

export default PlayerTable;
