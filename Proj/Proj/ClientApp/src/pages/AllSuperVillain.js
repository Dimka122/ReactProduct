import { Row } from "react-bootstrap";
import Card from "react-bootstrap/Card";
import Col from "react-bootstrap/Col";
import { useEffect, useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import Button from "react-bootstrap/Button";
 
function AllSuperVillain() {
    const navigate = useNavigate();
  const [superVillains, setSuperVillains] = useState([]);
 
  useEffect(() => {
    axios.get("https://localhost:7273/SuperVillain").then((response) => {
      setSuperVillains((data) => {
        return response.data;
      });
    });
  }, []);
 
  return (
    <>
    <Row className="mt-2">
        <Col md={{ span: 4, offset: 4 }}>
          <Button
            variant="primary"
            type="button"
            onClick={() => navigate("/supervillain-create")}
          >
            Add A Villain
          </Button>
        </Col>
      </Row>
      <Row md={3} className="g-4 mt-1">
        {superVillains.map((sv) => {
          return (
            <Col key={sv.id}>
              <Card>
                <Card.Img variant="top" src={sv.imageUrl} />
                <Card.Body>
                  <Card.Title>{sv.villainName}</Card.Title>
                  <Card.Text>
                    <b>Franchis:</b> {sv.franchise}
                  </Card.Text>
                  <Card.Text>
                    <b>Powers: </b>
                    {sv.powers}
                  </Card.Text>
                  <Button
                    variant="primary"
                    onClick={() => navigate(`/supervillain-update/${sv.id}`)}
                  >
                    Edit
                  </Button>
                </Card.Body>
              </Card>
            </Col>
          );
        })}
      </Row>
    </>
  );
}
 
export default AllSuperVillain;