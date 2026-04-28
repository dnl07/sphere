import { useState } from "react";
import ConfirmDialog from "../../../../shared/components/ConfirmDialog";
import DeleteIcon from "../../../../shared/components/ui/icons/DeleteIcon";
import EditIcon from "../../../../shared/components/ui/icons/EditIcon";
import { useDeleteClothingItem } from "../../../clothing/hooks/useDeleteClothingItem";
import { useLocation, useNavigate } from "react-router";

type Props = {
    itemId: string
}

const ItemActions = ({ itemId }: Props) => {
    const navigate = useNavigate();
    const location = useLocation();

    const [showDialog, setShowDialog] = useState<boolean>(false);
    const { deleteItem } = useDeleteClothingItem();

    return (
        <>
            <div className="flex flex-row gap-5 mr-1">
                <button className=""><EditIcon color="#000000" strokeWidth={1.5} className="w-7.5 h-7.5 cursor-pointer"/></button>
                <button onClick={() => setShowDialog(true)}><DeleteIcon color="#000000" strokeWidth={1.25} className="w-8 h-8 cursor-pointer" /></button>
            </div>     
            {showDialog && 
                <ConfirmDialog 
                    message="Are you sure you want to delete this item?" 
                    onConfirm={async () => {await deleteItem(itemId); navigate(location.state?.from ?? -1, { replace: true })}} 
                    onCancel={() => setShowDialog(false)}
                />
            } 
        </>
    );
};

export default ItemActions;