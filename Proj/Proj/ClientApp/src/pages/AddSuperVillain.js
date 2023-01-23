import { useRef } from "react";
import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";
import axios from "axios";
import { useNavigate } from "react-router-dom";
 
function AddSuperVillain() {
  const superVillainName = useRef("");
  const franchise = useRef("");
  const powers = useRef("");
  const imgUrl = useRef("");
 
  const navigate = useNavigate();
 
  function addVillainHandler() {
    var payload = {
      villainName: superVillainName.current.value,
      powers: powers.current.value,
      franchise: franchise.current.value,
      imageUrl: imgUrl.current.value,
    };
 
    axios
      .post("https://localhost:7273/SuperVillain", payload)
      .then((response) => {
        navigate("/");
      });
  }
 
  return (
    <>
      <legend>Add A New SuperVilian Character</legend>
      <form>
        <Form.Group className="mb-3" controlId="formSuperVillainName">
          <Form.Label>Super Villain Name</Form.Label>
          <Form.Control type="text" ref={superVillainName} />
        </Form.Group>
        <Form.Group className="mb-3" controlId="formFranchise">
          <Form.Label>Franchise</Form.Label>
          <Form.Control type="text" ref={franchise} />
        </Form.Group>
        <Form.Group className="mb-3" controlId="formPowers">
          <Form.Label>Powers</Form.Label>
          <Form.Control as="textarea" rows={3} ref={powers} />
        </Form.Group>
        <Form.Group className="mb-3" controlId="formImgUrl">
          <Form.Label>Image URL</Form.Label>
          <Form.Control type="text" ref={imgUrl} />
        </Form.Group>
      </form>
      <Button variant="primary" type="button" onClick={addVillainHandler}>
        Submit
      </Button>
    </>
  );
}
export default AddSuperVillain;